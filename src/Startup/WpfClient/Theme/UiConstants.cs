using System.Windows;

namespace WpfClient.Theme
{
    internal static class UiConstants
    {
        #region Spacing

        public const double TextSpacing = 5d;
        public const double InnerSpacing = 15d;
        public const double OuterSpacing = 30d;

        public static readonly GridLength TextSpacingGridLength = new GridLength(TextSpacing);
        public static readonly GridLength InnerSpacingGridLength = new GridLength(InnerSpacing);
        public static readonly GridLength OuterSpacingGridLength = new GridLength(OuterSpacing);

        public static readonly Thickness TextSpacingThickness = new Thickness(TextSpacing);
        public static readonly Thickness InnerSpacingThickness = new Thickness(InnerSpacing);
        public static readonly Thickness OuterSpacingThickness = new Thickness(OuterSpacing);

        #endregion
    }
}