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
        private InMemorySecretKeyStore ()
        {
        }

        public static readonly InMemorySecretKeyStore Instance = new InMemorySecretKeyStore ();

        private readonly IDictionary<string,string> _store = new ConcurrentDictionary<string, string> ();

        /// <summary>
        /// Stores the given secret key for the given key id.
        /// </summary>
        public void StoreSecretKey(string keyId, string secretKey) {
            if (keyId.IsBlank())
            {
                throw new ArgumentException ("keyId is required");
            }
            if (secretKey.IsBlank()) {
                throw new ArgumentException("secretKey is required");
            }
            _store.Add(keyId, secretKey);
        }

        /// <summary>
        /// Removes the secret key for the given key id.
        /// </summary>
        public void RemoveSecretKey(string keyId) {
            _store.Remove (keyId);
        }

        /// <summary>
        /// Removes all stored secret keys
        /// </summary>
        public void Clear() {
            _store.Clear ();
        }

        public string GetSecretKey(string keyId)
        {
            if (_store.TryGetValue(keyId, out var secretKey))
            {
                return secretKey;
            }
            throw new SecretKeyNotAvailableException("Could not find secret key for key id" + keyId, keyId);
        }
    }
}
