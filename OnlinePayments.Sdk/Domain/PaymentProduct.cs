/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct
    {
        /// <summary>
        /// List of tokens for that payment product<para />
        /// </summary>
        public IList<AccountOnFile> AccountsOnFile { get; set; } = null;

        /// <summary>
        /// Indicates if the product supports recurring payments<para />
        /// * true - This payment product supports recurring payments<para />
        /// * false - This payment product does not support recurring transactions and can only be used for one-off payments<para />
        /// </summary>
        public bool? AllowsRecurring { get; set; } = null;

        /// <summary>
        /// Indicates if the payment details can be tokenized for future re-use<para />
        /// * true - Payment details from payments done with this payment product can be tokenized for future re-use<para />
        /// * false - Payment details from payments done with this payment product can not be tokenized<para />
        /// </summary>
        public bool? AllowsTokenization { get; set; } = null;

        /// <summary>
        /// Object containing display hints like the order of the product when shown in a list, the name of the product and the logo<para />
        /// </summary>
        public PaymentProductDisplayHints DisplayHints { get; set; } = null;

        /// <summary>
        /// List of display hints<para />
        /// </summary>
        public IList<PaymentProductDisplayHints> DisplayHintsList { get; set; } = null;

        /// <summary>
        /// Object containing all the fields and their details that are associated with this payment product. If you are not interested in the data on the fields you should have us filter them our (using filter=fields in the query-string)<para />
        /// </summary>
        public IList<PaymentProductField> Fields { get; set; } = null;

        /// <summary>
        /// The ID of the payment product in our system<para />
        /// </summary>
        public int? Id { get; set; } = null;

        /// <summary>
        /// Payment method identifier used by the our payment engine.<para />
        /// </summary>
        public string PaymentMethod { get; set; } = null;

        public PaymentProduct302SpecificData PaymentProduct302SpecificData { get; set; } = null;

        public PaymentProduct320SpecificData PaymentProduct320SpecificData { get; set; } = null;

        /// <summary>
        /// The payment product group that has this payment product, if there is any. Not populated otherwise. Currently only one payment product group is supported:<para />
        /// * cards<para />
        /// </summary>
        public string PaymentProductGroup { get; set; } = null;

        /// <summary>
        /// Indicates whether the payment product requires redirection to a third party to complete the payment. You can use this to filter out products that require a redirect if you do not want to support that.<para />
        /// * true - Redirection is required<para />
        /// * false - No redirection is required<para />
        /// </summary>
        public bool? UsesRedirectionTo3rdParty { get; set; } = null;
    }
}
