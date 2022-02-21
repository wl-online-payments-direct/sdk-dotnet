using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Webhooks
{
    /// <summary>
    /// An in-memory secret key store.
    /// This implementation can be used in applications where secret keys can be specified at application startup.
    /// Thread-safe.
    /// </summary>
    public class InMemorySecretKeyStore : ISecretKeyStore
    {
        public static readonly InMemorySecretKeyStore Instance = new InMemorySecretKeyStore ();

        private readonly IDictionary<string,string> _store = new ConcurrentDictionary<string, string> ();

        private InMemorySecretKeyStore ()
        {
        }

        /// <summary>
        /// Stores the given secret key for the given key id.
        /// </summary>
        public void StoreSecretKey(string keyId, string secretKey)
        {
            if (String.IsNullOrWhiteSpace(keyId))
            {
                throw new ArgumentNullException ("keyId is required");
            }
            if (String.IsNullOrWhiteSpace(secretKey))
            {
                throw new ArgumentNullException("secretKey is required");
            }
            _store.Add(keyId, secretKey);
        }

        /// <summary>
        /// Removes the secret key for the given key id.
        /// </summary>
        public void RemoveSecretKey(string keyId)
        {
            _store.Remove (keyId);
        }

        /// <summary>
        /// Removes all stored secret keys
        /// </summary>
        public void Clear()
        {
            _store.Clear ();
        }

        public string GetSecretKey(string keyId)
        {
            if (_store.TryGetValue(keyId, out string secretKey))
            {
                return secretKey;
            }
            throw new SecretKeyNotAvailableException("Could not find secret key for key id" + keyId, keyId);
        }
    }
}
