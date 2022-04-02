using System.Windows;

namespace WpfClient.Theme
{
    internal static class UiSizes
    {
        #region Spacing

        public const double BorderSize = 1d;
        public const double TextSpacing = 2d;
        public const double InnerSpacing = 5d;
        public const double OuterSpacing = 10d;

        public static readonly GridLength InnerSpacingGridLength = new(InnerSpacing);
        public static readonly GridLength OuterSpacingGridLength = new(OuterSpacing);

        public static readonly Thickness TextSpacingThickness = new(TextSpacing);
        public static readonly Thickness InnerSpacingThickness = new(InnerSpacing);
        public static readonly Thickness OuterSpacingThickness = new(OuterSpacing);

        public static readonly Thickness InnerSpacingRightThickness = new(0d, 0d, InnerSpacing, 0d);
        public static readonly Thickness InnerSpacingLeftThickness = new(InnerSpacing, 0d, 0d, 0d);
        public static readonly Thickness OuterSpacingRightThickness = new(0d, 0d, OuterSpacing, 0d);
        public static readonly Thickness OuterSpacingLeftThickness = new(OuterSpacing, 0d, 0d, 0d);

        #endregion

        public static readonly Thickness BorderThickness = new(BorderSize);
    }
}