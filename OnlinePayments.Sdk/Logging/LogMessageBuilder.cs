using System;
using System.Text;

namespace OnlinePayments.Sdk.Logging
{
    /// <summary>
    /// A utility class to build log messages.
    /// </summary>
    public abstract class LogMessageBuilder
    {
        private readonly StringBuilder _headers = new StringBuilder();

        public abstract string Message { get; }

        protected string RequestId { get; }
        protected string Headers => _headers.ToString();
        protected string Body { get; private set; }
        protected string ContentType { get; private set; }
        protected string Charset { get; private set; }

        public void AddHeader(string name, string value)
        {
            if (_headers.Length > 0)
            {
                _headers.Append(", ");
            }

            _headers.Append(name)
                .Append("=\"");
            if (value != null)
            {
                string obfuscatedValue = LoggingUtil.ObfuscateHeader(name, value);
                _headers.Append(obfuscatedValue);
            }
            _headers.Append("\"");
        }

        public void SetBody(string body, string contentType)
        {
            Body = LoggingUtil.ObfuscateBody(body);
            ContentType = contentType;
        }

        protected LogMessageBuilder(string requestId)
        {
            if (string.IsNullOrEmpty(requestId))
            {
                throw new ArgumentException("requestId is required");
            }

            RequestId = requestId;
        }

        protected string EmptyIfNull(string value)
        {
            return value ?? "";
        }
    }
}
