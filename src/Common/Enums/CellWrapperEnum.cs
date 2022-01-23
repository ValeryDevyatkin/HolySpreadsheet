using System.ComponentModel.DataAnnotations;

namespace Common.Enums
{
    public enum CellWrapperEnum
    {
        None,

        [Display(Name = "Quotes", Description = "'cell' 'cell' 'cell'")]
        Quotes,

        [Display(Name = "Double quotes", Description = "\"cell\" \"cell\" \"cell\"")]
        DoubleQuotes,

        Custom
    }
}