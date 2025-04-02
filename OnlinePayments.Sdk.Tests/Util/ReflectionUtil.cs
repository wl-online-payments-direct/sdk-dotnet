using System;
using System.Reflection;

namespace OnlinePayments.Sdk.Util
{
    public static class ReflectionUtil
    {
        internal static T GetPrivateProperty<T>(this object instance, string fieldName)
        {
            const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var property = instance.GetType().GetProperty(fieldName, bindFlags);
            return (T)property.GetValue(instance);
        }

        internal static object GetPrivateField<T>(this T instance, string fieldName)
        {
            var type = typeof(T);
            return GetPrivateField(instance, type, fieldName);
        }

        internal static object GetPrivateField(this object instance, Type type, string fieldName)
        {
            const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var field = type.GetField(fieldName, bindFlags);
            return field?.GetValue(instance);
        }
    }
}
