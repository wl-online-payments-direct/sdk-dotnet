using System.Linq;
using Newtonsoft.Json.Serialization;

namespace OnlinePayments.Sdk.Json
{
    internal sealed class CamelCaseKeepFullCapsNamingStrategy : CamelCaseNamingStrategy
    {
        public CamelCaseKeepFullCapsNamingStrategy()
        {
            OverrideSpecifiedNames = true;
            ProcessDictionaryKeys = true;
        }

        protected override string ResolvePropertyName(string name)
        {
            var baseName = base.ResolvePropertyName(name);
            var isAllCaps = name.All(char.IsUpper);
            return isAllCaps ? baseName.ToUpper() : baseName;
        }
    }
}
