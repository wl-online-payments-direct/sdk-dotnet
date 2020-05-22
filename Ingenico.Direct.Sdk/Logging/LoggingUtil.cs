namespace Ingenico.Direct.Sdk.Logging
{
    /// <summary>
    /// A utility class to support logging.
    /// </summary>
    public class LoggingUtil
    {
        /// <summary>
        /// Obfuscates the given body as necessary.
        /// </summary>
        public static string ObfuscateBody(string body)
        {
            return PROPERTY_OBFUSCATOR.Obfuscate(body);
        }

        /// <summary>
        /// Obfuscates the value for the given header as necessary.
        /// </summary>
        public static string ObfuscateHeader(string name, string value)
        {
            return HEADER_OBFUSCATOR.ObfuscateValue(name, value);
        }

        private static readonly PropertyObfuscator PROPERTY_OBFUSCATOR = PropertyObfuscator.Builder()
            .WithKeepEndCount("cardNumber", 4)
            .WithKeepEndCount("expiryDate", 2)
            .WithAll("cvv")
            .WithKeepEndCount("iban", 4)
            .WithKeepEndCount("accountNumber", 4)
            .WithKeepEndCount("reformattedAccountNumber", 4)
            .WithKeepStartCount("bin", 6)
            .WithAll("value") // key-value pairs can contain any value, like credit card numbers or other private data; mask all values
            .WithFixedLength("keyId", 8)
            .WithFixedLength("secretKey", 8)
            .WithFixedLength("publicKey", 8)
            .WithFixedLength("userAuthenticationToken", 8)
            .WithFixedLength("encryptedPayload", 8) // encrypted payload is a base64 string that contains an encrypted value; to make decrypting even harder, just mask the entire thing
            .WithFixedLength("decryptedPayload", 8) // decrypted payload is a simple base64 string that may contain credit card numbers or other private data; just mask the entire thing
            .WithFixedLength("encryptedCustomerInput", 8) // encrypted customer input is similar to encrypted payload
            .Build();

        private static readonly HeaderObfuscator HEADER_OBFUSCATOR = HeaderObfuscator.Builder()
            .WithFixedLength("Authorization", 8)
            .WithFixedLength("WWW-Authenticate", 8)
            .WithFixedLength("Proxy-Authenticate", 8)
            .WithFixedLength("Proxy-Authorization", 8)
            .WithFixedLength("X-GCS-Authentication-Token", 8)
            .WithFixedLength("X-GCS-CallerPassword", 8)
            .Build();

        LoggingUtil()
        {

        }
    }
}
