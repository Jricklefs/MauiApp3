#if ANDROID
using MauiApp3.Platforms.Android.Services;
#endif
namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            SubscribeToDeviceChanges();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        //var customButton = new CustomMediaRouteButton();
        //customButton.Clicked += OnCustomButtonClicked;

         async void OnCustomButtonClicked(object sender, EventArgs e)
        {
            var deviceDiscoveryService = DependencyService.Get<IDeviceDiscoveryService>();
            var devices = await deviceDiscoveryService.GetAvailableDevicesAsync();
        }

       

        private void SubscribeToDeviceChanges()
        {
            var deviceDiscoveryService = DependencyService.Get<IDeviceDiscoveryService>();
            if (deviceDiscoveryService is DeviceDiscoveryService androidDeviceDiscoveryService)
            {
                androidDeviceDiscoveryService.DevicesChanged += OnDevicesChanged;
            }
        }

        private void OnDevicesChanged(object sender, EventArgs e)
        {
            // Assuming your CustomMediaRouteButton is named customMediaRouteButton
            var ooo = "";
            MainThread.BeginInvokeOnMainThread(() =>
            {
                CustomMediaBtn.IsEnabled = true;
                // Other UI updates can be done here
            });
            // Optionally, you can also update the button's appearance here
        }
        // Don't forget to unsubscribe from the event when the page is destroyed
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (DependencyService.Get<IDeviceDiscoveryService>() is DeviceDiscoveryService androidDeviceDiscoveryService)
            {
                androidDeviceDiscoveryService.DevicesChanged -= OnDevicesChanged;
            }
        }
    }

}
