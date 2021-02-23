using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.ShowingMultipleShells.Core;

namespace Prism.ShowingMultipleShells.UI.ViewModels
{
    public class MainWindowViewModel : BindableBase, IRegionManagerAware
    {
        private readonly IShellService _service;

        public DelegateCommand<string> OpenShellCommand { get; private set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public IRegionManager RegionManager { get; set; }

        public MainWindowViewModel(IShellService service)
        {
            _service = service;

            OpenShellCommand = new(OpenShell);
            NavigateCommand = new(Navigate);
        }

        private void OpenShell(string viewName) => _service.ShowShell(viewName);

        private void Navigate(string viewName) => RegionManager.RequestNavigate(KnownRegionNames.ContentRegion, viewName);
    }
}