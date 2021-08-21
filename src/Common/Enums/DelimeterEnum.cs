using System.ComponentModel.DataAnnotations;

namespace Common.Enums
{
    public enum DelimiterEnum : byte
    {
        [Display(Name = "Whitespace", Description = "xxx xxx xxx          xxx")]
        Whitespace,

        [Display(Name = "Tab", Description = "xxx   xxx   xxx   xxx")]
        Tab,

        [Display(Name = "Comma", Description = "xxx, xxx, xxx, xxx")]
        Comma,

        [Display(Name = "Semicolon", Description = "xxx; xxx; xxx; xxx")]
        Semicolon,

        [Display(Name = "Custom", Description = "Specify delimiter via text box")]
        Custom
    }
}