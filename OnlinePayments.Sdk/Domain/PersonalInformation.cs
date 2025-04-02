/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PersonalInformation
    {
        /// <summary>
        /// The date of birth of the customer of the recipient of the loan.
        /// Format YYYYMMDD
        /// </summary>
        public string DateOfBirth { get; set; }

        /// <summary>
        /// The gender of the customer. All values are possible as long as it does not exceed the maximum length of 50 characters.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Object containing the name details of the customer
        /// </summary>
        public PersonalName Name { get; set; }
    }
}
