using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Base class of all payment platform API resources.
    /// </summary>
    public class ApiResource
    {
        private readonly ApiResource _parent;
        private readonly IDictionary<string, string> _pathContext;
        protected readonly ICommunicator _communicator;
        protected readonly string _clientMetaInfo;

        protected ApiResource(ApiResource parent, IDictionary<string, string> pathContext)
        {
            _parent = parent ?? throw new ArgumentException("parent is required");
            _pathContext = pathContext;
            _communicator = parent._communicator;
            _clientMetaInfo = parent._clientMetaInfo;
        }

        protected ApiResource(ICommunicator communicator, string clientMetaInfo, IDictionary<string, string> pathContext)
        {
            _parent = null;
            _pathContext = pathContext;
            _communicator = communicator ?? throw new ArgumentException("communicator is required");
            _clientMetaInfo = clientMetaInfo;
        }

        protected List<RequestHeader> ClientHeaders
        {
            get
            {
                return _clientMetaInfo == null
                    ? null
                    : new List<RequestHeader>
                    {
                        new RequestHeader("X-GCS-ClientMetaInfo", _clientMetaInfo)
                    };
            }
        }

        protected string InstantiateUri(string uri, IDictionary<string, string> pathContext)
        {
            uri = ReplaceAll(uri, pathContext);
            return InstantiateUri(uri);
        }

        protected Exception CreateException(HttpStatusCode statusCode, string responseBody, object errorObject, CallContext context)
        {
            if (errorObject is PaymentErrorResponse paymentErrorResp && paymentErrorResp.PaymentResult != null)
            {
                return new DeclinedPaymentException(statusCode, responseBody, paymentErrorResp);
            }
            if (errorObject is PayoutErrorResponse response && response.PayoutResult != null)
            {
                return new DeclinedPayoutException(statusCode, responseBody, response);
            }
            if (errorObject is RefundErrorResponse refundErrorResp && refundErrorResp.RefundResult != null)
            {
                return new DeclinedRefundException(statusCode, responseBody, refundErrorResp);
            }

            string errorId;
            IList<APIError> errors;
            if (errorObject == null)
            {
                errorId = null;
                errors = new List<APIError>();
            }
            else if (errorObject is PaymentErrorResponse paymentErrorResponse)
            {
                errorId = paymentErrorResponse.ErrorId;
                errors = paymentErrorResponse.Errors;
            }
            else if (errorObject is PayoutErrorResponse payoutErrorResponse)
            {
                errorId = payoutErrorResponse.ErrorId;
                errors = payoutErrorResponse.Errors;
            }
            else if (errorObject is RefundErrorResponse refundErrorResponse)
            {
                errorId = refundErrorResponse.ErrorId;
                errors = refundErrorResponse.Errors;
            }
            else if (errorObject is ErrorResponse errorResponse)
            {
                errorId = errorResponse.ErrorId;
                errors = errorResponse.Errors;
            }
            else
            {
                throw new ArgumentException("unsupported error object type: " + errorObject.GetType().ToString());
            }

            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    return new ValidationException(statusCode, responseBody, errorId, errors);
                case HttpStatusCode.Forbidden:
                    return new AuthorizationException(statusCode, responseBody, errorId, errors);
                case HttpStatusCode.NotFound:
                    return new ReferenceException(statusCode, responseBody, errorId, errors);
                case HttpStatusCode.Conflict:
                    if (IsIdempotenceError(errors, context))
                    {
                        string idempotenceKey = context.IdempotenceKey;
                        long? idempotenceRequestTimestamp = context.IdempotenceRequestTimestamp;
                        return new IdempotenceException(idempotenceKey, idempotenceRequestTimestamp, statusCode, responseBody, errorId, errors);
                    }
                    return new ReferenceException(statusCode, responseBody, errorId, errors);
                case HttpStatusCode.Gone:
                    return new ReferenceException(statusCode, responseBody, errorId, errors);
                case HttpStatusCode.InternalServerError:
                    return new PaymentPlatformException(statusCode, responseBody, errorId, errors);
                case HttpStatusCode.BadGateway:
                    return new PaymentPlatformException(statusCode, responseBody, errorId, errors);
                case HttpStatusCode.ServiceUnavailable:
                    return new PaymentPlatformException(statusCode, responseBody, errorId, errors);
                default:
                    return new ApiException(statusCode, responseBody, errorId, errors);
            }
        }

        string InstantiateUri(string uri)
        {
            uri = ReplaceAll(uri, _pathContext);
            if (_parent != null)
            {
                uri = _parent.InstantiateUri(uri);
            }
            return uri;
        }

        static string ReplaceAll(string uri, IDictionary<string, string> pathContext)
        {
            if (pathContext != null)
            {
                foreach (var entry in pathContext)
                {
                    uri = uri.Replace("{" + entry.Key + "}", entry.Value);
                }
            }
            return uri;
        }

        static bool IsIdempotenceError(IEnumerable<APIError> errors, CallContext context)
        {
            return context != null
                    && context.IdempotenceKey != null
                    && errors.Count() == 1
                    && "1409".Equals(errors.ElementAt(0).Code);
        }
    }
}
