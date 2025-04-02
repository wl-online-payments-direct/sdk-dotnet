using NUnit.Framework;
using System;
using System.IO;

namespace OnlinePayments.Sdk.Logging
{
    [TestFixture]
    public class SysOutCommunicatorLoggerTest
    {
        private TextWriter _oldStdOut;
        private TextWriter _newStdOut;

        [TestCase]
        public void TestLogUnicode()
        {
            _oldStdOut = Console.Out;
            _newStdOut = new StringWriter();
            Console.SetOut(_newStdOut);
            try
            {
                var logger = SystemConsoleCommunicatorLogger.Instance;
                logger.Log("Schröder");
                var aString = _newStdOut.ToString();
                StringAssert.EndsWith("Schröder" + Environment.NewLine, aString);
            }
            finally
            {
                Console.SetOut(_oldStdOut);
            }
        }
        [TestCase]
        public void TestLog()
        {
            _oldStdOut = Console.Out;
            _newStdOut = new StringWriter();
            Console.SetOut(_newStdOut);
            try
            {
                var logger = SystemConsoleCommunicatorLogger.Instance;
                logger.Log("Hello world");
                var aString = _newStdOut.ToString();
                StringAssert.EndsWith("Hello world" + Environment.NewLine, aString);
            }
            finally
            {
                Console.SetOut(_oldStdOut);
            }
        }
        [TestCase]
        public void TestLogWithException()
        {
            _oldStdOut = Console.Out;
            _newStdOut = new StringWriter();
            Console.SetOut(_newStdOut);
            try
            {
                var logger = SystemConsoleCommunicatorLogger.Instance;
                var exception = new Exception();
                try
                {
                    throw exception;
                }
                catch (Exception e) {
                    logger.Log("Hello world", e);
                }
                var aString = _newStdOut.ToString();
                StringAssert.EndsWith("Hello world" + Environment.NewLine + exception + Environment.NewLine, aString);
            }
            finally
            {
                Console.SetOut(_oldStdOut);
            }
        }
    }
}
