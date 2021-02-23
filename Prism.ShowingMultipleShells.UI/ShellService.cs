using Prism.Ioc;
using Prism.Regions;
using Prism.ShowingMultipleShells.Core;
using Prism.ShowingMultipleShells.UI.Views;

namespace Prism.ShowingMultipleShells.UI
{
    public class ShellService : IShellService
    {
        private readonly IContainerProvider _container;
        private readonly IRegionManager _regionManager;

        public ShellService(IContainerProvider container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void ShowShell(string uri)
        {
            var shell = _container.Resolve<MainWindow>();

            var scopedRegion = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(shell, scopedRegion);

            RegionManagerAware.SetRegionManagerAware(shell, scopedRegion);

            scopedRegion.RequestNavigate(KnownRegionNames.ContentRegion, uri);

            shell.Show();
        }
    }
}