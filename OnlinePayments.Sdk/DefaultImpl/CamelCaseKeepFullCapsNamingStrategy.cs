using Newtonsoft.Json.Serialization;

namespace OnlinePayments.Sdk.DefaultImpl
{
    sealed class CamelCaseKeepFullCapsNamingStrategy : CamelCaseNamingStrategy
    {
        public CamelCaseKeepFullCapsNamingStrategy()
        {
            OverrideSpecifiedNames = true;
            ProcessDictionaryKeys = true;
        }

        protected override string ResolvePropertyName(string name)
        {
            var baseName = base.ResolvePropertyName(name);
            var isAllCaps = true;
            foreach (var c in name)
            {
                if (!char.IsUpper(c))
                {
                    isAllCaps = false;
                    break;
                }
            }
            return isAllCaps ? baseName.ToUpper() : baseName;
        }
    }
}
