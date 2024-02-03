using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.CustomControls
{
    public class DeviceListViewModel
    {
        private readonly IDeviceDiscoveryService _deviceDiscoveryService;

        public ObservableCollection<string> AvailableDevices { get; } = new ObservableCollection<string>();

        public DeviceListViewModel(IDeviceDiscoveryService deviceDiscoveryService)
        {
            _deviceDiscoveryService = deviceDiscoveryService;
            // Subscribe to the DevicesChanged event
            _deviceDiscoveryService.DevicesChanged += OnDevicesChanged;
        }

        private async void OnDevicesChanged(object sender, EventArgs e)
        {
            // Update the AvailableDevices collection in response to the event
            var devices = await _deviceDiscoveryService.GetAvailableDevicesAsync();
            AvailableDevices.Clear();
            foreach (var device in devices)
            {
                AvailableDevices.Add(device);
            }
        }

        // Don't forget to unsubscribe from the event when the view model is no longer in use
        public void Dispose()
        {
            _deviceDiscoveryService.DevicesChanged -= OnDevicesChanged;
        }
    }
}
