using Android.Gms.Cast;
using AndroidX.MediaRouter.Media;
using AU = Android.Util;

namespace MauiApp3.Platforms.Android.Services
{
    public class DeviceDiscoveryService : IDeviceDiscoveryService
    {
        private readonly MediaRouter _mediaRouter;
        private readonly MediaRouteSelector _mediaRouteSelector;
        
        private readonly List<string> _deviceNames = new List<string>();

        //public event EventHandler DevicesChanged;
        public DeviceDiscoveryService()
        {
            _mediaRouter = MainActivity.MediaRouterInstance;
            _mediaRouteSelector = MainActivity.MediaRouteSelectorInstance;
            _mediaRouter.AddCallback(_mediaRouteSelector, new MediaRouterCallback(this), MediaRouter.CallbackFlagRequestDiscovery);
        }

        private class MediaRouterCallback : MediaRouter.Callback
        {
            private readonly DeviceDiscoveryService _service;

            public MediaRouterCallback(DeviceDiscoveryService service)
            {
                _service = service;
            }

            /// <summary>
            /// Leaving this so that you can see the Devices that were found.  Not required just Nice to see. Remove when you get it working the way you want. 
            /// </summary>
            /// <param name="router"></param>
            /// <param name="route"></param>
            public override void OnRouteAdded(MediaRouter router, MediaRouter.RouteInfo route)
            {
                base.OnRouteAdded(router, route);
                _service._deviceNames.Add(route.Name);
                AU.Log.Debug("MainActivity", $"Route added: {route.Name}");
                // Notify subscribers that devices have changed
               // _service.DevicesChanged?.Invoke(this, EventArgs.Empty);
            }

            public override void OnRouteRemoved(MediaRouter router, MediaRouter.RouteInfo route)
            {
                base.OnRouteRemoved(router, route);
                _service._deviceNames.Remove(route.Name);
            }


        }
    }
}
