/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.Services
{
    /// <inheritdoc/>
    public class ServicesClient : ApiResource, IServicesClient
    {
        public ServicesClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <inheritdoc/>
        public async Task<CalculateSurchargeResponse> SurchargeCalculation(CalculateSurchargeRequest body, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/services/surchargecalculation", null);
            try
            {
                return await _communicator.Post<CalculateSurchargeResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        body,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<CurrencyConversionResponse> GetDccRateInquiry(CurrencyConversionRequest body, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/services/dccrate", null);
            try
            {
                return await _communicator.Post<CurrencyConversionResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        body,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<GetPrivacyPolicyResponse> GetPrivacyPolicy(GetPrivacyPolicyParams query, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/services/privacypolicy", null);
            try
            {
                return await _communicator.Get<GetPrivacyPolicyResponse>(
                        uri,
                        ClientHeaders,
                        query,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<TestConnection> TestConnection(CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/services/testconnection", null);
            try
            {
                return await _communicator.Get<TestConnection>(
                        uri,
                        ClientHeaders,
                        null,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<GetIINDetailsResponse> GetIINDetails(GetIINDetailsRequest body, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/services/getIINdetails", null);
            try
            {
                return await _communicator.Post<GetIINDetailsResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        body,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }
    }
}
