using NUnit.Framework;

namespace OnlinePayments.Sdk.Logging
{
    [TestFixture]
    public class BodyObfuscatorTest
    {
        private const string NoObfuscation = @"{
    ""order"": {
        ""amountOfMoney"": {
            ""currencyCode"": ""EUR"",
            ""amount"": 1000
        },
        ""customer"": {
            ""locale"": ""nl_NL"",
            ""billingAddress"": {
                ""countryCode"": ""NL""
            }
        }
    },
    ""bankTransferPaymentMethodSpecificInput"": {
        ""paymentProductId"": 11
    }
}";
        private const string BinObfuscated = @"{
    ""bin"": ""123456**""
}";
        private const string BinUnobfuscated = @"{
    ""bin"": ""12345678""
}";

        private const string CardObfuscated = @"{
    ""order"": {
        ""amountOfMoney"": {
            ""currencyCode"": ""CAD"",
            ""amount"": 2345
        },
        ""customer"": {
            ""billingAddress"": {
                ""countryCode"": ""CA""
            }
        }
    },
    ""cardPaymentMethodSpecificInput"": {
        ""paymentProductId"": 1,
        ""card"": {
            ""cvv"": ""***"",
            ""cardNumber"": ""************3456"",
            ""expiryDate"": ""**20""
        }
    }
}";
        private const string CardObfuscatedCustom = @"{
    ""order"": {
        ""amountOfMoney"": {
            ""currencyCode"": ""CAD"",
            ""amount"": 2345
        },
        ""customer"": {
            ""billingAddress"": {
                ""countryCode"": ""CA""
            }
        }
    },
    ""cardPaymentMethodSpecificInput"": {
        ""paymentProductId"": 1,
        ""card"": {
            ""cvv"": ""***"",
            ""cardNumber"": ""123456******3456"",
            ""expiryDate"": ""**20""
        }
    }
}";
        private const string CardUnObfuscated = @"{
    ""order"": {
        ""amountOfMoney"": {
            ""currencyCode"": ""CAD"",
            ""amount"": 2345
        },
        ""customer"": {
            ""billingAddress"": {
                ""countryCode"": ""CA""
            }
        }
    },
    ""cardPaymentMethodSpecificInput"": {
        ""paymentProductId"": 1,
        ""card"": {
            ""cvv"": ""123"",
            ""cardNumber"": ""1234567890123456"",
            ""expiryDate"": ""1220""
        }
    }
}";

        private const string IbanObfuscated = @"{
    ""sepaDirectDebit"": {
        ""mandate"": {
            ""bankAccountIban"": {
                ""iban"": ""**************4567""
            },
            ""debtor"": {
                ""lastName"": ""Jones""
            },
            ""isRecurring"": false
        },
        ""customer"": {
            ""billingAddress"": {
                ""countryCode"": ""NL""
            }
        }
    },
    ""paymentProductId"": 770
}";
        private const string IbanUnobfuscated = @"{
    ""sepaDirectDebit"": {
        ""mandate"": {
            ""bankAccountIban"": {
                ""iban"": ""NL00INGB0001234567""
            },
            ""debtor"": {
                ""lastName"": ""Jones""
            },
            ""isRecurring"": false
        },
        ""customer"": {
            ""billingAddress"": {
                ""countryCode"": ""NL""
            }
        }
    },
    ""paymentProductId"": 770
}";

        private const string NoObjectObfuscationUnobfuscated = @"{
    ""value"" : true,
    ""value"" : {
    }
}";
        private const string NoObjectObfuscationObfuscated = @"{
    ""value"" : ****,
    ""value"" : {
    }
}";

        [TestCase]
        public void TestObfuscateBodyWithNullBody()
        {
            var obfuscatedBody = BodyObfuscator.DefaultObfuscator.ObfuscateBody(null);

            Assert.Null(obfuscatedBody);
        }

        [TestCase]
        public void TestObfuscateBodyWithEmptyBody()
        {
            const string body = "";

            var obfuscatedBody = BodyObfuscator.DefaultObfuscator.ObfuscateBody(body);

            Assert.AreEqual(body, obfuscatedBody);
        }

        [TestCase]
        public void TestObfuscateBodyWithCard()
        {
            CheckObfuscatedBodyWithMatches(CardUnObfuscated, CardObfuscated);
        }

        [TestCase]
        public void TestObfuscateBodyWithCustomCardRule()
        {
            var bodyObfuscator = BodyObfuscator.Custom()
                    .ObfuscateCustom("cardNumber", KeepFirst6AndLast4)
                    .Build();

            CheckObfuscatedBodyWithMatches(bodyObfuscator, CardUnObfuscated, CardObfuscatedCustom);
        }

        [TestCase]
        public void TestObfuscateBodyWithIban()
        {
            CheckObfuscatedBodyWithMatches(IbanUnobfuscated, IbanObfuscated);
        }

        [TestCase]
        public void TestObfuscateBodyWithBin()
        {
            CheckObfuscatedBodyWithMatches(BinUnobfuscated, BinObfuscated);
        }

        [TestCase]
        public void TestObfuscateBodyWithNoMatches()
        {
            CheckObfuscatedBodyWithNoMatches(NoObfuscation);
        }

        [TestCase]
        public void TestObfuscateBodyWithObject()
        {
            CheckObfuscatedBodyWithMatches(NoObjectObfuscationUnobfuscated, NoObjectObfuscationObfuscated);
        }

        private static void CheckObfuscatedBodyWithMatches(string body, string expected)
        {
            CheckObfuscatedBodyWithMatches(BodyObfuscator.DefaultObfuscator, body, expected);
        }

        private static void CheckObfuscatedBodyWithMatches(BodyObfuscator bodyObfuscator, string body, string expected)
        {
            var obfuscatedBody = bodyObfuscator.ObfuscateBody(body);

            Assert.AreEqual(expected, obfuscatedBody);
        }

        private static void CheckObfuscatedBodyWithNoMatches(string body)
        {
            var obfuscatedBody = BodyObfuscator.DefaultObfuscator.ObfuscateBody(body);

            Assert.AreEqual(body, obfuscatedBody);
        }

        private static string KeepFirst6AndLast4(string value)
        {
            var chars = value.ToCharArray();
            for (var i = 6; i < chars.Length - 4; i++)
            {
                chars[i] = '*';
            }
            return new string(chars);
        }
    }
}
