using System.ComponentModel.DataAnnotations;

namespace Common.Enums
{
    public enum RowWrapperEnum
    {
        None,

        [Display(Name = "Coma", Description = "ROW ,")]
        Coma,

        [Display(Name = "Parentheses and coma", Description = "( ROW ) ,")]
        ParenthesesAndComa,

        Custom
    }
}