using System;

namespace OnlinePayments.Sdk.Communication
{
    /// <summary>
    /// Indicates an exception regarding the communication with the Online Payments platform such as a connection exception.
    /// </summary>
    public class CommunicationException : Exception
    {
        public CommunicationException(Exception e)
            : base("There was an error in the communication with the Online Payments platform", e)
        {

        }
    }
}
