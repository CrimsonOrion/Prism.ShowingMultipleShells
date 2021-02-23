using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.ShowingMultipleShells.Core;
using Prism.ShowingMultipleShells.UI.Views;

using System.Windows;

namespace Prism.ShowingMultipleShells.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell() => Container.Resolve<MainWindow>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry) => containerRegistry.Register<IShellService, ShellService>();

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) => moduleCatalog.AddModule<ModuleA.ModuleAModule>();

        protected override void InitializeShell(Window shell)
        {
            var regionManager = RegionManager.GetRegionManager(MainWindow);
            RegionManagerAware.SetRegionManagerAware(MainWindow, regionManager);
            base.InitializeShell(shell);
        }

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            base.ConfigureDefaultRegionBehaviors(regionBehaviors);
            regionBehaviors.AddIfMissing(RegionManagerAwareBehavior.BehaviorKey, typeof(RegionManagerAwareBehavior));
        }
    }
}