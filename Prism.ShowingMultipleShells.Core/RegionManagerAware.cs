using Prism.Regions;

using System.Windows;

namespace Prism.ShowingMultipleShells.Core
{
    public static class RegionManagerAware
    {
        public static void SetRegionManagerAware(object item, IRegionManager regionManager)
        {
            var rmAware = item as IRegionManagerAware;
            if (rmAware is not null)
                rmAware.RegionManager = regionManager;

            var rmAwareFrameworkElement = item as FrameworkElement;

            if (rmAwareFrameworkElement is not null)
            {
                var rmAwareDataContext = rmAwareFrameworkElement.DataContext as IRegionManagerAware;
                if (rmAwareDataContext is not null)
                    rmAwareDataContext.RegionManager = regionManager;
            }

        }
    }
}