using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.ShowingMultipleShells.ModuleA.Views;

namespace Prism.ShowingMultipleShells.ModuleA
{
    public class ModuleAModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) =>
            containerProvider
            .Resolve<IRegionManager>()
            .RegisterViewWithRegion("ContentRegion", typeof(ViewA))
            .RegisterViewWithRegion("ContentRegion", typeof(ViewB));

        public void RegisterTypes(IContainerRegistry containerRegistry) =>
            containerRegistry
                .Register<ViewA>()
                .Register<ViewB>();
    }
}