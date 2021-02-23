using Prism.Regions;

using System;
using System.Collections.Specialized;
using System.Windows;

namespace Prism.ShowingMultipleShells.Core
{
    public class RegionManagerAwareBehavior : RegionBehavior
    {
        public const string BehaviorKey = "RegionManagerAwareBehavior";
        protected override void OnAttach() => Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;

        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    var regionManager = Region.RegionManager;

                    var element = item as FrameworkElement;
                    if (element is not null)
                    {
                        var scopedRegionManager = element.GetValue(RegionManager.RegionManagerProperty) as IRegionManager;

                        if (scopedRegionManager is not null)
                            regionManager = scopedRegionManager;
                    }

                    InvokeOnRegionManagerAwareElement(item, x => x.RegionManager = regionManager);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                    InvokeOnRegionManagerAwareElement(item, x => x.RegionManager = null);
            }
        }

        private static void InvokeOnRegionManagerAwareElement(object item, Action<IRegionManagerAware> invocation)
        {
            var rmAwareItem = item as IRegionManagerAware;
            if (rmAwareItem is not null)
                invocation(rmAwareItem);

            var frameworkElement = item as FrameworkElement;
            if (frameworkElement is not null)
            {
                var rmAwareDataContext = frameworkElement.DataContext as IRegionManagerAware;
                if (rmAwareDataContext is not null)
                {
                    var frameworkElementParent = frameworkElement.Parent as FrameworkElement;
                    if (frameworkElementParent is not null)
                    {
                        var rmAwareDataContextParent = frameworkElementParent.DataContext as IRegionManagerAware;
                        if (rmAwareDataContextParent is not null)
                        {
                            if (rmAwareDataContext == rmAwareDataContextParent)
                                return;
                        }
                    }

                    invocation(rmAwareDataContext);
                }
            }
        }
    }
}