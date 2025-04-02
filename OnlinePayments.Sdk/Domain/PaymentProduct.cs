/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct
    {
        /// <summary>
        /// List of tokens for that payment product
        /// </summary>
        public IList<AccountOnFile> AccountsOnFile { get; set; }

        /// <summary>
        /// True when 3DS authentication is supported or required for the product
        /// </summary>
        public bool? AllowsAuthentication { get; set; }

        /// <summary>
        /// Indicates if the product supports recurring payments
        /// <list type="bullet">
        ///   <item><description>true - This payment product supports recurring payments</description></item>
        ///   <item><description>false - This payment product does not support recurring transactions and can only be used for one-off payments</description></item>
        /// </list>
        /// </summary>
        public bool? AllowsRecurring { get; set; }

        /// <summary>
        /// Indicates if the payment details can be tokenized for future re-use
        /// <list type="bullet">
        ///   <item><description>true - Payment details from payments done with this payment product can be tokenized for future re-use</description></item>
        ///   <item><description>false - Payment details from payments done with this payment product can not be tokenized</description></item>
        /// </list>
        /// </summary>
        public bool? AllowsTokenization { get; set; }

        /// <summary>
        /// Object containing display hints like the order of the product when shown in a list, the name of the product and the logo
        /// </summary>
        public PaymentProductDisplayHints DisplayHints { get; set; }

        public IList<PaymentProductDisplayHints> DisplayHintsList { get; set; }

        /// <summary>
        /// Object containing all the fields and their details that are associated with this payment product. If you are not interested in the data on the fields you should have us filter them our (using filter=fields in the query-string)
        /// </summary>
        public IList<PaymentProductField> Fields { get; set; }

        /// <summary>
        /// The ID of the payment product in our system
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Payment method identifier used by the our payment engine.
        /// </summary>
        public string PaymentMethod { get; set; }

        public PaymentProduct302SpecificData PaymentProduct302SpecificData { get; set; }

        public PaymentProduct320SpecificData PaymentProduct320SpecificData { get; set; }

        /// <summary>
        /// The payment product group that has this payment product, if there is any. Not populated otherwise. Currently only one payment product group is supported:
        /// <list type="bullet">
        ///   <item><description>cards</description></item>
        /// </list>
        /// </summary>
        public string PaymentProductGroup { get; set; }

        /// <summary>
        /// Indicates whether the payment product requires redirection to a third party to complete the payment. You can use this to filter out products that require a redirect if you do not want to support that.
        /// <list type="bullet">
        ///   <item><description>true - Redirection is required</description></item>
        ///   <item><description>false - No redirection is required</description></item>
        /// </list>
        /// </summary>
        public bool? UsesRedirectionTo3rdParty { get; set; }
    }
}
