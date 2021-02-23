using Prism.Regions;

namespace Prism.ShowingMultipleShells.Core
{
    public interface IRegionManagerAware
    {
        IRegionManager RegionManager { get; set; }
    }
}