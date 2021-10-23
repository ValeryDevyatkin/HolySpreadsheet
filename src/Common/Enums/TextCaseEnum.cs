using System.ComponentModel.DataAnnotations;

namespace Common.Enums
{
    public enum TextCaseEnum : byte
    {
        [Display(Name = "No Formatting")] Default,

        [Display(Name = "All Lower", Description = "xxx xxx xxx")]
        AllLower,

        [Display(Name = "All Upper", Description = "XXX XXX XXX")]
        AllUpper,

        [Display(Name = "First Upper",
                 Description = "[Xxx Xxx] [Xxx Xxx] [Xxx Xxx]\nRemoves extra spaces between words in a cell!")]
        FirstUpper
    }
}