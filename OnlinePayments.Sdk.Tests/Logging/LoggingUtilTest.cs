using NUnit.Framework;

namespace OnlinePayments.Sdk.Logging
{
    [TestFixture]
    public class LoggingUtilTest
    {
        const string noObfuscation = @"{
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
        const string binObfuscated = @"{
    ""bin"": ""*8""
}";
        const string binUnobfuscated = @"{
    ""bin"": ""12345678""
}";
        const string cardObfuscated = @"{
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
            ""cvv"": ""*3"",
            ""cardNumber"": ""*16"",
            ""expiryDate"": ""*4""
        }
    }
}";
        const string cardUnobfuscated = @"{
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
            ""expiryDate"": ""1230""
        }
    }
}";
        const string gdprObfuscated = @"{
    ""order"": {
        ""amountOfMoney"": {
            ""currencyCode"": ""EUR"",
            ""amount"": 2345
        },
        ""customer"": {
            ""billingAddress"": {
                ""countryCode"": ""BE"",
                ""city"": ""Zaventem"",
                ""zip"": ""*4"",
                ""street"": ""*12"",
                ""houseNumber"": ""*1""
            },
            ""personalInformation"": {
                ""dateOfBirth"": ""*8"",
                ""name"": {
                    ""firstName"": ""*4"",
                    ""surname"": ""*6""
                }
            },
            ""contactDetails"": {
                ""emailAddress"": ""*17"",
                ""faxNumber"": ""*18"",
                ""mobilePhoneNumber"": ""*11"",
                ""phoneNumber"": ""*12"",
                ""workPhoneNumber"": ""*12""
            }
        }
    }
}";
        const string gdprUnobfuscated = @"{
    ""order"": {
        ""amountOfMoney"": {
            ""currencyCode"": ""EUR"",
            ""amount"": 2345
        },
        ""customer"": {
            ""billingAddress"": {
                ""countryCode"": ""BE"",
                ""city"": ""Zaventem"",
                ""zip"": ""1930"",
                ""street"": ""Da Vincilaan"",
                ""houseNumber"": ""3""
            },
            ""personalInformation"": {
                ""dateOfBirth"": ""19370929"",
                ""name"": {
                    ""firstName"": ""Wile"",
                    ""surname"": ""Coyote""
                }
            },
            ""contactDetails"": {
                ""emailAddress"": ""wecoyote@acme.org"",
                ""faxNumber"": ""+32 (0)2 286 96 16"",
                ""mobilePhoneNumber"": ""+3222869611"",
                ""phoneNumber"": ""02 585 56 80"",
                ""workPhoneNumber"": ""003222869611""
            }
        }
    }
}";
        const string ibanObfuscated = @"{
    ""sepaDirectDebit"": {
        ""mandate"": {
            ""bankAccountIban"": {
                ""iban"": ""*18""
            },
            ""debtor"": {
                ""surname"": ""*5""
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
        const string ibanUnobfuscated = @"{
    ""sepaDirectDebit"": {
        ""mandate"": {
            ""bankAccountIban"": {
                ""iban"": ""NL00INGB0001234567""
            },
            ""debtor"": {
                ""surname"": ""Jones""
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
        const string noObjectObfuscationUnobfuscated = @"{
    ""value"" : true,
    ""value"" : {
    }
}";
        const string noObjectObfuscationObfuscated = @"{
    ""value"" : *4,
    ""value"" : {
    }
}";

        [TestCase]
        public void TestObfuscateBodyWithNullBody()
        {
            string body = null;

            string obfuscatedBody = LoggingUtil.ObfuscateBody(body);

            Assert.Null(obfuscatedBody);
        }

        [TestCase]
        public void TestObfuscateBodyWithEmptyBody()
        {
            string body = "";

            string obfuscatedBody = LoggingUtil.ObfuscateBody(body);

            Assert.AreEqual(body, obfuscatedBody);
        }

        [TestCase]
        public void TestObfuscateBodyWithBin()
        {
            CheckObfuscatedBodyWithMatches(binUnobfuscated, binObfuscated);
        }

        [TestCase]
        public void TestObfuscateBodyWithCard()
        {
            CheckObfuscatedBodyWithMatches(cardUnobfuscated, cardObfuscated);
        }

        [TestCase]
        public void TestObfuscateBodyWithGDPRData()
        {
            CheckObfuscatedBodyWithMatches(gdprUnobfuscated, gdprObfuscated);
        }

        [TestCase]
        public void TestObfuscateBodyWithIban()
        {
            CheckObfuscatedBodyWithMatches(ibanUnobfuscated, ibanObfuscated);
        }

        [TestCase]
        public void TestObfuscateBodyWithNoMatches()
        {
            CheckObfuscatedBodyWithMatches(noObfuscation);
        }

        [TestCase]
        public void TestObfuscateBodyWithObject()
        {
            CheckObfuscatedBodyWithMatches(noObjectObfuscationUnobfuscated, noObjectObfuscationObfuscated);
        }

        [TestCase]
        public void TestObfuscateHeader()
        {
            CheckObfuscateHeaderWithMatch("Authorization", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "***");
            CheckObfuscateHeaderWithMatch("authorization", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "***");
            CheckObfuscateHeaderWithMatch("AUTHORIZATION", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "***");

            CheckObfuscateHeaderWithMatch("X-GCS-Authentication-Token", "foobar", "***");
            CheckObfuscateHeaderWithMatch("x-gcs-authentication-token", "foobar", "***");
            CheckObfuscateHeaderWithMatch("X-GCS-AUTHENTICATION-TOKEN", "foobar", "***");

            CheckObfuscateHeaderWithMatch("X-GCS-CallerPassword", "foobar", "***");
            CheckObfuscateHeaderWithMatch("x-gcs-callerpassword", "foobar", "***");
            CheckObfuscateHeaderWithMatch("X-GCS-CALLERPASSWORD", "foobar", "***");

            CheckObfuscateHeaderWithNoMatch("Content-Type", "application/json");
            CheckObfuscateHeaderWithNoMatch("content-type", "application/json");
            CheckObfuscateHeaderWithNoMatch("CONTENT-TYPE", "application/json");
        }

        void CheckObfuscatedBodyWithMatches(string body, string expected)
        {
            string obfuscatedBody = LoggingUtil.ObfuscateBody(body);

            Assert.AreEqual(expected, obfuscatedBody);
        }

        void CheckObfuscatedBodyWithMatches(string body)
        {
            string obfuscatedBody = LoggingUtil.ObfuscateBody(body);

            Assert.AreEqual(body, obfuscatedBody);
        }

        void CheckObfuscateHeaderWithMatch(string name, string originalValue, string expectedObfuscatedValue)
        {
            string obfuscatedValue = LoggingUtil.ObfuscateHeader(name, originalValue);

            Assert.AreEqual(expectedObfuscatedValue, obfuscatedValue);
        }

        void CheckObfuscateHeaderWithNoMatch(string name, string originalValue)
        {
            string obfuscatedValue = LoggingUtil.ObfuscateHeader(name, originalValue);

            Assert.AreEqual(originalValue, obfuscatedValue);
        }
    }
}
