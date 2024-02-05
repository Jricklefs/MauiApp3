#if ANDROID
using MauiApp3.Platforms.Android.Services;
#endif
namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {


        int count = 0;
       //private bool _canCast;

        ////public bool CanCast
        ////{
        ////    get => _canCast;
        ////    set
        ////    {
        ////        if (_canCast != value)
        ////        {
        ////            _canCast = value;
        ////            OnPropertyChanged(nameof(CanCast));
        ////        }
        ////    }
        ////}
        public MainPage()
        {
            InitializeComponent();
            //BindingContext = this;
            ////SubscribeToDeviceChanges();

            ////MessagingCenter.Subscribe<object, string>(this, "ShowPopup", (sender, arg) =>
            ////{
            ////    // Show your popup here
            ////    ShowPopup();
            ////});

            // _deviceDiscoveryService = DependencyService.Get<IDeviceDiscoveryService>() as DeviceDiscoveryService;

        }
        ////private void ShowPopup()
        ////{

        ////    var ThereShouldBePopuphere = "";
        ////    // Logic to show the popup
        ////}
        ////private void OnShowDevicesPopup(object sender, EventArgs e)
        ////{
        ////    // Logic to show the popup
        ////    // This could be calling a method on CustomMediaRouteButton or directly showing a popup view
        ////    Device.BeginInvokeOnMainThread(() =>
        ////    {

        ////        // Replace with actual logic to show your popup
        ////        // For example, you could use Rg.Plugins.Popup or any other popup plugin/library you have
        ////    });
        ////}

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

        //// async void OnCustomButtonClicked(object sender, EventArgs e)
        ////{
        ////    var deviceDiscoveryService = DependencyService.Get<IDeviceDiscoveryService>();
        ////    //var devices = await deviceDiscoveryService.GetAvailableDevicesAsync();
        ////}

       

        ////private void SubscribeToDeviceChanges()
        ////{
        ////    var deviceDiscoveryService = DependencyService.Get<IDeviceDiscoveryService>();
        ////    deviceDiscoveryService.DevicesChanged += OnDevicesChanged;
        ////}

        ////private void OnDevicesChanged(object sender, EventArgs e)
        ////{
        ////    MainThread.BeginInvokeOnMainThread(async () =>
        ////    {
        ////        // Assuming you want to do something with the updated list of devices,
        ////        // like displaying them in the UI
        ////        var deviceDiscoveryService = DependencyService.Get<IDeviceDiscoveryService>();
        ////       // var devices = await deviceDiscoveryService.GetAvailableDevicesAsync();

        ////       // CanCast = devices.Any();
        ////        // TODO: Update the UI with the list of devices
        ////        // For example, if you have a ListView or similar control to display the devices
        ////    });
        ////}
        // Don't forget to unsubscribe from the event when the page is destroyed
        ////protected override void OnDisappearing()
        ////{
        ////    base.OnDisappearing();
        ////    MessagingCenter.Send<object, string>(this, "ShowPopup", "Button clicked");
        ////    if (DependencyService.Get<IDeviceDiscoveryService>() is DeviceDiscoveryService androidDeviceDiscoveryService)
        ////    {
        ////        androidDeviceDiscoveryService.DevicesChanged -= OnDevicesChanged;
               
        ////    }
        ////}
    }

}
