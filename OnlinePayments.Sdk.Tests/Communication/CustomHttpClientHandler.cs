using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace OnlinePayments.Sdk.Communication
{
    internal class CustomHttpClientHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-Custom-Header-ID", "custom-header");

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
