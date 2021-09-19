using BAJIEPA.Senticode.Wpf;
using Unity;

namespace WpfClient.Views.Regions
{
    internal partial class GridRegion
    {
        public GridRegion()
        {
            ServiceLocator.Container.RegisterInstance(this);
            InitializeComponent();
        }
    }
}