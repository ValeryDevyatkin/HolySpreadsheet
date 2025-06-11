using System.ComponentModel.DataAnnotations;

namespace Common.Enums
{
    public enum DelimiterEnum : byte
    {
        [Display(Name = "Whitespace", Description = "cell cell cell")]
        Whitespace,

        [Display(Name = "Tab", Description = "cell   cell   cell")]
        Tab,

        [Display(Name = "Comma", Description = "cell, cell, cell")]
        Comma,

        [Display(Name = "Semicolon", Description = "cell; cell; cell")]
        Semicolon,

        Custom
    }
}