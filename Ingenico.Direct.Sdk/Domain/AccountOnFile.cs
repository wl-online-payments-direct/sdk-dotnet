/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class AccountOnFile
    {
        public IList<AccountOnFileAttribute> Attributes { get; set; } = null;

        public AccountOnFileDisplayHints DisplayHints { get; set; } = null;

        public int? Id { get; set; } = null;

        public int? PaymentProductId { get; set; } = null;
    }
}
