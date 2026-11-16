using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlinePayments.Sdk;
using OnlinePayments.Sdk.Merchant;

namespace Examples
{
    /// <summary>
    /// The settings of the integration, bound from the "OnlinePayments" configuration section.
    /// Locally keep the values in user secrets (dotnet user-secrets set "OnlinePayments:ApiSecret" "..."), in
    /// production in your secret store or in environment variables (OnlinePayments__ApiSecret). Never in a
    /// file of the repository.
    /// </summary>
    public class OnlinePaymentsOptions
    {
        // Test or live endpoint, e.g. https://payment.direct.ecom.preprod.worldline-solutions.com
        [Required, Url]
        public string ApiEndpoint { get; set; }

        [Required]
        public string ApiKeyId { get; set; }

        [Required]
        public string ApiSecret { get; set; }

        // The merchant ID is your PSPID.
        [Required]
        public string MerchantId { get; set; }

        // Your company or application name; it identifies your requests in the platform logs.
        // Mandatory: the SDK throws "integrator is required" without it.
        [Required]
        public string Integrator { get; set; }

        // The absolute public base URL of your shop, e.g. https://shop.example. Return URLs are built from it,
        // never from the request's Host header.
        [Required, Url]
        public string PublicBaseUrl { get; set; }

        // Webhook key ID and secret from the Merchant Portal (Developer > Webhooks).
        [Required]
        public string WebhookKeyId { get; set; }

        [Required]
        public string WebhookSecret { get; set; }
    }

    public static class ClientSetup
    {
        // [START client-setup]
        // ASP.NET Core: bind and validate the settings once, so that a missing value stops the application at
        // startup with a clear message instead of failing on the first payment. Register one client for the
        // whole application. It is thread-safe; never create a client per request.
        public static void AddPaymentClient(IServiceCollection services)
        {
            services.AddOptions<OnlinePaymentsOptions>()
                .BindConfiguration("OnlinePayments")
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.AddHttpClient("OnlinePayments");

            services.AddSingleton<IClient>(serviceProvider =>
            {
                OnlinePaymentsOptions options = serviceProvider.GetRequiredService<IOptions<OnlinePaymentsOptions>>().Value;
                var configuration = new CommunicatorConfiguration
                {
                    ApiEndpoint = new Uri(options.ApiEndpoint),
                    ApiKeyId = options.ApiKeyId,
                    SecretApiKey = options.ApiSecret,
                    Integrator = options.Integrator,
                }.WithHttpClientFactory(serviceProvider.GetRequiredService<IHttpClientFactory>(), "OnlinePayments");

                return Factory.CreateClient(configuration);
            });

            // Every API call goes through the merchant client.
            services.AddSingleton<IMerchantClient>(serviceProvider =>
                serviceProvider.GetRequiredService<IClient>()
                    .WithNewMerchant(serviceProvider.GetRequiredService<IOptions<OnlinePaymentsOptions>>().Value.MerchantId));
        }
        // [END client-setup]
    }
}
