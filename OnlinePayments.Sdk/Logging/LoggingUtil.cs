namespace OnlinePayments.Sdk.Logging
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
            .WithField("cardNumber")
            .WithField("expiryDate")
            .WithField("cvv")
            .WithField("iban")
            .WithField("accountNumber")
            .WithField("reformattedAccountNumber")
            .WithField("bin")
            .WithField("additionalInfo")
            .WithField("cardholderName")
            .WithField("dateOfBirth")
            .WithField("emailAddress")
            .WithField("faxNumber")
            .WithField("firstName")
            .WithField("houseNumber")
            .WithField("mobilePhoneNumber")
            .WithField("passengerName")
            .WithField("phoneNumber")
            .WithField("street")
            .WithField("surname")
            .WithField("workPhoneNumber")
            .WithField("zip")
            .WithField("value") // key-value pairs can contain any value, like credit card numbers or other private data; mask all values
            .WithSensitiveField("keyId")
            .WithSensitiveField("secretKey")
            .WithSensitiveField("publicKey")
            .WithSensitiveField("userAuthenticationToken")
            .WithSensitiveField("encryptedPayload") // encrypted payload is a base64 string that contains an encrypted value; to make decrypting even harder, just mask the entire thing
            .WithSensitiveField("decryptedPayload") // decrypted payload is a simple base64 string that may contain credit card numbers or other private data; just mask the entire thing
            .WithSensitiveField("encryptedCustomerInput") // encrypted customer input is similar to encrypted payload
            .Build();

        private static readonly HeaderObfuscator HEADER_OBFUSCATOR = HeaderObfuscator.Builder()
            .WithSensitiveField("Authorization")
            .WithSensitiveField("WWW-Authenticate")
            .WithSensitiveField("Proxy-Authenticate")
            .WithSensitiveField("Proxy-Authorization")
            .WithSensitiveField("X-GCS-Authentication-Token")
            .WithSensitiveField("X-GCS-CallerPassword")
            .Build();

        LoggingUtil()
        {

        }
    }
}
