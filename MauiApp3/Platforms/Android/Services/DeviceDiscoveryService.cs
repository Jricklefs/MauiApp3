using Android.Content;
using AndroidX.MediaRouter.Media;
using AU = Android.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Gms.Cast;

namespace MauiApp3.Platforms.Android.Services
{
    public class DeviceDiscoveryService : IDeviceDiscoveryService
    {
        private readonly MediaRouter _mediaRouter;
        private readonly MediaRouteSelector _mediaRouteSelector;
        private readonly MediaRouterCallback _mediaRouterCallback;
        private readonly List<string> _deviceNames = new List<string>();

        public event EventHandler DevicesChanged;
        public DeviceDiscoveryService()
        {
            // Use the static context from MainActivity
            var context = MainActivity.AppContext;

            _mediaRouteSelector = new MediaRouteSelector.Builder()
            .AddControlCategory(CastMediaControlIntent.CategoryForCast("7AA05E47")) // Replace with your actual Cast receiver app ID.
            .Build();

            _mediaRouterCallback = new MediaRouterCallback(this);

            _mediaRouter = MediaRouter.GetInstance(context);
            _mediaRouter.AddCallback(_mediaRouteSelector, _mediaRouterCallback, MediaRouter.CallbackFlagRequestDiscovery);
        }

        // Implement device discovery logic here
        public  Task<IEnumerable<string>> GetAvailableDevicesAsync()
        {
            return Task.FromResult(_deviceNames.AsEnumerable());
        }

        public async Task ConnectToDeviceAsync(string deviceName)
        {
            // Connect to the device
        }

        private class MediaRouterCallback : MediaRouter.Callback
        {
            private readonly DeviceDiscoveryService _service;

            public MediaRouterCallback(DeviceDiscoveryService service)
            {
                _service = service;
            }

            public override void OnRouteAdded(MediaRouter router, MediaRouter.RouteInfo route)
            {
                base.OnRouteAdded(router, route);
                _service._deviceNames.Add(route.Name);
                AU.Log.Debug("MainActivity", $"Route added: {route.Name}");
                // Notify subscribers that devices have changed
                _service.DevicesChanged?.Invoke(_service, EventArgs.Empty);
            }

            public override void OnRouteRemoved(MediaRouter router, MediaRouter.RouteInfo route)
            {
                base.OnRouteRemoved(router, route);
                _service._deviceNames.Remove(route.Name);
            }


        }
    }
}
