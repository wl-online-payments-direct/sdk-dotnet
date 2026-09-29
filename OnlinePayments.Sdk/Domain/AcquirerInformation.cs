/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AcquirerInformation
    {
        /// <summary>
        /// Information about the acquirer selection
        /// </summary>
        public AcquirerSelectionInformation AcquirerSelectionInformation { get; set; }

        /// <summary>
        /// Name of the acquirer used to process the transaction
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AcquirerInformation WithAcquirerSelectionInformation(AcquirerSelectionInformation value)
        {
            AcquirerSelectionInformation = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AcquirerInformation WithName(string value)
        {
            Name = value;
            return this;
        }
    }
}
