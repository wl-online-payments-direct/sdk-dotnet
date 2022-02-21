using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OnlinePayments.Sdk.DefaultImpl
{
    /// <summary>
    /// <see cref="IMarshaller"/> implementation based on <a href="http://www.newtonsoft.com/json">Json.NET</a>.
    /// </summary>
    public sealed class DefaultMarshaller : IMarshaller
    {
        private static readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseKeepFullCapsNamingStrategy()
            },
            NullValueHandling = NullValueHandling.Ignore
        };

        private JsonSerializer _serializer;

        private DefaultMarshaller()
        {
            _serializer = JsonSerializer.Create(_jsonSerializerSettings);
        }

        public static DefaultMarshaller Instance { get; } = new DefaultMarshaller();

        #region IMarshaller Implementation
        public string Marshal(object requestObject) => JsonConvert.SerializeObject(requestObject, _jsonSerializerSettings);

        public T Unmarshal<T>(string responseJson)
        {
            try
            {
                return (T)JsonConvert.DeserializeObject(responseJson, typeof(T), _jsonSerializerSettings);
            }
            catch (JsonReaderException exception)
            {
                throw new MarshallerSyntaxException(exception);
            }
        }

        public T Unmarshal<T>(Stream responseJson)
        {
            try
            {
                var sr = new StreamReader(responseJson);
                var jr = new JsonTextReader(sr);
                return _serializer.Deserialize<T>(jr);
            }
            catch (JsonReaderException exception)
            {
                throw new MarshallerSyntaxException(exception);
            }
        }
        #endregion
    }
}
