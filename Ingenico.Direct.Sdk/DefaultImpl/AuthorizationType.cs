using System;

namespace Ingenico.Direct.Sdk.DefaultImpl
{
    public class AuthorizationType
    {
        #region enum
        public static readonly AuthorizationType V1HMAC = new AuthorizationType("v1HMAC");
        #endregion

        AuthorizationType(string signatureString)
        {
            SignatureString = signatureString;
        }

        public string SignatureString { get; }

        #region Static
        /// <summary>
        /// Returns the enum value of the specified string.
        /// </summary>
        public static AuthorizationType GetValueOf(string aString)
        {
            if (V1HMAC.SignatureString.Equals(aString))
            {
                return V1HMAC;
            }
            throw new ArgumentException("Unsupported Authorization");
        }
        #endregion
    }
}
