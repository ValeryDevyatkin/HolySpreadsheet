using System.Windows;

namespace WpfClient.Theme
{
    internal static class UiConstants
    {
        #region Spacing

        public const double TextSpacing = 2d;
        public const double InnerSpacing = 5d;
        public const double OuterSpacing = 10d;

        public static readonly GridLength TextSpacingGridLength = new GridLength(TextSpacing);
        public static readonly GridLength InnerSpacingGridLength = new GridLength(InnerSpacing);
        public static readonly GridLength OuterSpacingGridLength = new GridLength(OuterSpacing);

        public static readonly Thickness TextSpacingThickness = new Thickness(TextSpacing);
        public static readonly Thickness InnerSpacingThickness = new Thickness(InnerSpacing);
        public static readonly Thickness OuterSpacingThickness = new Thickness(OuterSpacing);

        public static readonly Thickness InnerSpacingRightThickness = new Thickness(0d, 0d, InnerSpacing, 0d);
        public static readonly Thickness InnerSpacingLeftThickness = new Thickness(InnerSpacing, 0d, 0d, 0d);

        #endregion
    }
}