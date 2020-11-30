namespace MebelDesign71.Web.Infrastructure
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    public static class EnumGetAttribute
    {
        public static string GetDescription<TEnum>(this TEnum value)
        where TEnum : struct, IConvertible // Enums do implement IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum is not an enum type :(");
            }

            var et = typeof(TEnum);
            var name = Enum.GetName(et, value);

            var result = et.GetField(name)
                ?.GetCustomAttributes(false)
                ?.OfType<DescriptionAttribute>()
                ?.FirstOrDefault()
                .Description
            ;

            return result;
        }
    }
}
