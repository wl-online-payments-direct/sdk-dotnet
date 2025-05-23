using System;
using NLog;

namespace OnlinePayments.Sdk.Logging
{
    /// <summary>
    /// A communicator logger that is backed by an <see cref="ILogger"/>.
    /// </summary>
    public class NLogCommunicatorLogger : ICommunicatorLogger
    {
        /// <summary>
        /// Creates a new communicator logger.
        /// </summary>
        /// <param name="logger">The backing logger.</param>
        /// <param name="level">The level to use when logging through both <see cref="Log(string)"/> abd <see cref="Log(string, Exception)"/>.</param>
        public NLogCommunicatorLogger(ILogger logger, LogLevel level) : this(logger, level, level)
        {

        }

        /// <summary>
        /// Creates a new communicator logger.
        /// </summary>
        /// <param name="logger">The backing logger.</param>
        /// <param name="logLevel">The level to use when logging through <see cref="Log(string)"/></param>
        /// <param name="errorLogLevel">The level to use when logging through <see cref="Log(string, Exception)"/></param>
        public NLogCommunicatorLogger(ILogger logger, LogLevel logLevel, LogLevel errorLogLevel)
        {
            _logger = logger ?? throw new ArgumentException("logger is required");
            _logLevel = logLevel ?? LogLevel.Debug;
            _errorLogLevel = errorLogLevel ?? LogLevel.Error;
        }

        #region ICommunicatorLogger Implementation
        public void Log(string message)
        {
            _logger.Log(_logLevel, message);
        }

        public void Log(string message, Exception exception)
        {
            _logger.Log(_errorLogLevel, message, exception, Array.Empty<object>());
        }
        #endregion

        private readonly ILogger _logger;
        private readonly LogLevel _logLevel;
        private readonly LogLevel _errorLogLevel;
    }
}
