using System;

namespace OnlinePayments.Sdk.Authentication
{
    public class AuthorizationType
    {
        #region enum
        public static readonly AuthorizationType V1HMAC = new AuthorizationType("v1HMAC");
        #endregion

        #region Static
        /// <summary>
        /// Returns the enum value of the specified string.
        /// </summary>
        public static AuthorizationType GetValueOf(string aString)
        {
            if (aString?.Equals(V1HMAC._stringValue) ?? false)
            {
                return V1HMAC;
            }
            throw new ArgumentException("Unsupported Authorization");
        }
        #endregion

        public override string ToString()
        {
            return _stringValue;
        }

        private AuthorizationType(string stringValue)
        {
            _stringValue = stringValue;
        }

        private readonly string _stringValue;
    }
}
