using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Common.Helpers
{
    public class EnumDisplayInfo
    {
        public string Name { get; internal set; }
        public string Description { get; internal set; }
    }

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