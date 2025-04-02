using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OnlinePayments.Sdk.Json
{
    /// <summary>
    /// <see cref="IMarshaller"/> implementation based on <a href="http://www.newtonsoft.com/json">Json.NET</a>.
    /// </summary>
    public sealed class DefaultMarshaller : IMarshaller
    {
        public static DefaultMarshaller Instance { get; } = new DefaultMarshaller();

        #region IMarshaller Implementation
        public string Marshal(object requestObject) => JsonConvert.SerializeObject(requestObject, JsonSerializerSettings);

        public T Unmarshal<T>(string responseJson)
        {
            try
            {
                return (T)JsonConvert.DeserializeObject(responseJson, typeof(T), JsonSerializerSettings);
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
                var serializer = JsonSerializer.Create(JsonSerializerSettings);

                return serializer.Deserialize<T>(jr);
            }
            catch (JsonReaderException exception)
            {
                throw new MarshallerSyntaxException(exception);
            }

        }

        #endregion

        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseKeepFullCapsNamingStrategy()
            },
            DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFK",
            NullValueHandling = NullValueHandling.Ignore
        };

        private DefaultMarshaller()
        {

        }
    }
}
