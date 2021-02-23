using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.ShowingMultipleShells.Core;

namespace Prism.ShowingMultipleShells.ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase, IRegionManagerAware
    {
        public DelegateCommand NavigateCommand { get; set; }

        private string _title = "View A";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ViewAViewModel() => NavigateCommand = new DelegateCommand(Navigate);

        private void Navigate() => RegionManager.RequestNavigate(KnownRegionNames.ContentRegion, "ViewB");

        public IRegionManager RegionManager { get; set; }
    }
}