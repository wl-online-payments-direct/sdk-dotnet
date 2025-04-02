namespace OnlinePayments.Sdk.Logging
{
    /// <summary>
    /// A utility class to build request log messages.
    /// </summary>
    public class RequestLogMessageBuilder : LogMessageBuilder
    {
        private const string MessageTemplateWithoutBody = @"Outgoing request (requestId='{0}'):
  method:       '{1}'
  uri:          '{2}'
  headers:      '{3}'";

        private const string MessageTemplateWithBody = MessageTemplateWithoutBody + @"
  content-type: '{4}'
  body:         '{5}'";

        public RequestLogMessageBuilder(string requestId, string method, string uri, BodyObfuscator bodyObfuscator, HeaderObfuscator headerObfuscator)
            : base(requestId, bodyObfuscator, headerObfuscator)
        {
            _method = method;
            _uri = uri;
        }

        public override string Message
        {
            get
            {
                var body = Body;
                if (body == null)
                {
                    return string.Format(MessageTemplateWithoutBody, RequestId,
                        EmptyIfNull(_method),
                        EmptyIfNull(_uri),
                        Headers);

                }

                return string.Format(MessageTemplateWithBody, RequestId,
                    EmptyIfNull(_method),
                    EmptyIfNull(_uri),
                    Headers,
                    EmptyIfNull(ContentType),
                    body);
            }
        }

        private readonly string _method;
        private readonly string _uri;
    }
}
