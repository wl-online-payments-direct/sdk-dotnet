using System;
using System.Net;

namespace OnlinePayments.Sdk.Logging
{
    /// <summary>
    /// A utility class to build response log messages.
    /// </summary>
    public class ResponseLogMessageBuilder : LogMessageBuilder
    {
        private const string MessageTemplate = @"Incoming response (requestId='{0}' + '{1}' ms):
  status-code:  '{2}'
  headers:      '{3}'
  content-type: '{4}'
  body:         '{5}'";

        public ResponseLogMessageBuilder(string requestId, HttpStatusCode statusCode, TimeSpan duration, BodyObfuscator bodyObfuscator, HeaderObfuscator headerObfuscator)
            : base(requestId, bodyObfuscator, headerObfuscator)
        {
            _statusCode = statusCode;
            Duration = duration;
        }

        public override string Message => string.Format(MessageTemplate, RequestId, (long)Duration.TotalMilliseconds,
            (int)_statusCode,
            Headers,
            EmptyIfNull(ContentType),
            EmptyIfNull(Body));

        public TimeSpan Duration { get; }

        private readonly HttpStatusCode _statusCode;
    }
}
