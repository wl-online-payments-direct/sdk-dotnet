using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.DefaultImpl 
{
    public class CustomHttpClientHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage httpRequest, CancellationToken cancellationToken
        ) {
            httpRequest.Headers.Add("X-Custom-Header-ID", "custom-header");

            return await base.SendAsync(httpRequest, cancellationToken);
        }
    }

}
