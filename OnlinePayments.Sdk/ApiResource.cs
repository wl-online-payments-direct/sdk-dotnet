using System;
using System.Collections.Generic;
using System.Linq;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Base class of all Online Payments platform API resources.
    /// </summary>
    public abstract class ApiResource
    {
        protected readonly ICommunicator _communicator;
        protected readonly string _clientMetaInfo;

        protected List<RequestHeader> ClientHeaders
        {
            get
            {
                var clientHeaders = new List<RequestHeader>();
                if (_clientMetaInfo != null)
                {
                    clientHeaders.Add(new RequestHeader("X-GCS-ClientMetaInfo", _clientMetaInfo));
                }
                return clientHeaders;
            }
        }

        protected ApiResource(ApiResource parent, IDictionary<string, string> pathContext)
        {
            _parent = parent ?? throw new ArgumentException("parent is required");
            _communicator = parent._communicator;
            _pathContext = pathContext;
            _clientMetaInfo = parent._clientMetaInfo;
        }

        protected ApiResource(ICommunicator communicator, string clientMetaInfo, IDictionary<string, string> pathContext)
        {
            _parent = null;
            _communicator = communicator ?? throw new ArgumentException("communicator is required");
            _pathContext = pathContext;
            _clientMetaInfo = clientMetaInfo;
        }

        protected string InstantiateUri(string uri, IDictionary<string, string> pathContext)
        {
            uri = ReplaceAll(uri, pathContext);
            uri = InstantiateUri(uri);
            return uri;
        }

        private readonly ApiResource _parent;
        private readonly IDictionary<string, string> _pathContext;

        private string InstantiateUri(string uri)
        {
            uri = ReplaceAll(uri, _pathContext);
            if (_parent != null)
            {
                uri = _parent.InstantiateUri(uri);
            }
            return uri;
        }

        private static string ReplaceAll(string uri, IDictionary<string, string> pathContext)
        {
            if (pathContext != null)
            {
                uri = pathContext.Aggregate(uri, (current, entry) => current.Replace("{" + entry.Key + "}", entry.Value));
            }
            return uri;
        }
    }
}
