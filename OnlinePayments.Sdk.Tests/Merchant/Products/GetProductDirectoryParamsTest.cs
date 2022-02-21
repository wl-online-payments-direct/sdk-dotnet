using NUnit.Framework;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Merchant.Products
{
    [TestFixture]
    public class GetProductDirectoryParamsTest
    {
        [TestCase]
        public void TestToRequestParameters()
        {
            GetProductDirectoryParams lParams = new GetProductDirectoryParams();
            var paramList = new List<RequestParam>();

            Assert.That(lParams.ToRequestParameters(), Is.EquivalentTo(paramList));

            lParams.CountryCode = "NL";
            paramList.Add(new RequestParam("countryCode", "NL"));
            Assert.That(lParams.ToRequestParameters(), Is.EquivalentTo(paramList));

            lParams.CurrencyCode = "EUR";
            paramList.Add(new RequestParam("currencyCode", "EUR"));
            Assert.That(lParams.ToRequestParameters(), Is.EquivalentTo(paramList));
        }
    }
}
