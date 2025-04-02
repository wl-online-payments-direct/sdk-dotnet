using System.Reflection;

namespace OnlinePayments.Sdk.Util
{
    public static class ReflectionUtil
    {
        internal static T GetPrivateProperty<T>(this object instance, string fieldName)
        {
            const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var property = instance.GetType().GetProperty(fieldName, bindFlags);
            return (T)property?.GetValue(instance);

        }
        internal static object GetPrivateField<T>(this T instance, string fieldName)
        {
            const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var field = typeof(T).GetField(fieldName, bindFlags);
            return field?.GetValue(instance);
        }
    }
}
