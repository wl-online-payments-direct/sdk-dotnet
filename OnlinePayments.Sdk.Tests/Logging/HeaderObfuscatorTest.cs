using NUnit.Framework;

namespace OnlinePayments.Sdk.Logging
{
    [TestFixture]
    public class HeaderObfuscatorTest
    {
        [TestCase]
        public void TestObfuscateHeader()
        {
            CheckObfuscateHeaderWithMatch("Authorization", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "********");
            CheckObfuscateHeaderWithMatch("authorization", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "********");
            CheckObfuscateHeaderWithMatch("AUTHORIZATION", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "********");

            CheckObfuscateHeaderWithNoMatch("Content-Type", "application/json");
            CheckObfuscateHeaderWithNoMatch("content-type", "application/json");
            CheckObfuscateHeaderWithNoMatch("CONTENT-TYPE", "application/json");
        }

        [TestCase]
        public void TestObfuscateCustomHeader()
        {
            var headerObfuscator = HeaderObfuscator.Custom()
                    .ObfuscateAll("content-type")
                    .Build();

            CheckObfuscateHeaderWithMatch(headerObfuscator, "Authorization", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "********");
            CheckObfuscateHeaderWithMatch(headerObfuscator, "authorization", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "********");
            CheckObfuscateHeaderWithMatch(headerObfuscator, "AUTHORIZATION", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "********");

            CheckObfuscateHeaderWithMatch(headerObfuscator, "Content-Type", "application/json", "****************");
            CheckObfuscateHeaderWithMatch(headerObfuscator, "content-type", "application/json", "****************");
            CheckObfuscateHeaderWithMatch(headerObfuscator, "CONTENT-TYPE", "application/json", "****************");
        }

        private static void CheckObfuscateHeaderWithMatch(string name, string originalValue, string expectedObfuscatedValue)
        {
            var obfuscatedValue = HeaderObfuscator.DefaultObfuscator.ObfuscateHeader(name, originalValue);

            Assert.AreEqual(expectedObfuscatedValue, obfuscatedValue);
        }

        private static void CheckObfuscateHeaderWithMatch(HeaderObfuscator headerObfuscator, string name, string originalValue, string expectedObfuscatedValue)
        {
            var obfuscatedValue = headerObfuscator.ObfuscateHeader(name, originalValue);

            Assert.AreEqual(expectedObfuscatedValue, obfuscatedValue);
        }

        private static void CheckObfuscateHeaderWithNoMatch(string name, string originalValue)
        {
            var obfuscatedValue = HeaderObfuscator.DefaultObfuscator.ObfuscateHeader(name, originalValue);

            Assert.AreEqual(originalValue, obfuscatedValue);
        }
    }
}
