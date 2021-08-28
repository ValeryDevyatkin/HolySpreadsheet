using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Common.Items;

namespace Common.Helpers
{
    public static class EnumHelper
    {
        public static EnumDisplayInfo GetDisplayInfo<TEnum>(this TEnum item)
            where TEnum : Enum
        {
            var stringValue = item.ToString();
            var memberInfo = item.GetType().GetMember(stringValue);
            var attribute = memberInfo[0].GetCustomAttribute<DisplayAttribute>();

            if (attribute == null)
            {
                return new EnumDisplayInfo {Name = stringValue};
            }

            var name = attribute.Name;

            if (string.IsNullOrWhiteSpace(name))
            {
                name = stringValue;
            }

            return new EnumDisplayInfo {Name = name, Description = attribute.Description};
        }
    }
}