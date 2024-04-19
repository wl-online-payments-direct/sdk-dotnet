using System;
using System.Net;

namespace OnlinePayments.Sdk.Logging
{
    /// <summary>
    /// A utility class to build response log messages.
    /// </summary>
    public class ResponseLogMessageBuilder : LogMessageBuilder
    {
        private const string messageTemplate = @"Incoming response (requestId='{0}' + '{1}' ms):
  status-code:  '{2}'
  headers:      '{3}'
  content-type: '{4}'
  body:         '{5}'";

        private readonly HttpStatusCode _statusCode;

        public ResponseLogMessageBuilder(string requestId, HttpStatusCode statusCode)
            : base(requestId)
        {
            _statusCode = statusCode;
        }

        public ResponseLogMessageBuilder(string requestId, HttpStatusCode statusCode, long duration)
            : base(requestId)
        {
            _statusCode = statusCode;
            Duration = TimeSpan.FromMilliseconds(duration);
        }

        public TimeSpan Duration { get; set; }

        public override string Message
        {
            get
            {
                return string.Format(messageTemplate, RequestId, (long)Duration.TotalMilliseconds,
                    (int)_statusCode,
                    Headers,
                    EmptyIfNull(ContentType),
                    EmptyIfNull(Body));
            }
        }
    }
}
