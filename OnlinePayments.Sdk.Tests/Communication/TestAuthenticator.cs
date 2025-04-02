using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Authentication;

namespace OnlinePayments.Sdk.Communication
{
    internal class TestAuthenticator : IAuthenticator
    {
        public Task<string> GetAuthorization(HttpMethod httpMethod, Uri resourceUri, IEnumerable<IRequestHeader> requestHeaders)
        {
            return Task.FromResult("Test");
        }
    }
}
