using Android.App;

using MauiApp3.CustomControls;
using Microsoft.Maui.Handlers;
using AndroidViews = Android.Views;

namespace MauiApp3.Platforms.Android.Handlers
{
    public partial class CustomMediaRouteButtonHandler : ViewHandler<CustomMediaRouteButton, MediaRouteButton>
    {
        public static IPropertyMapper<CustomMediaRouteButton, CustomMediaRouteButtonHandler> Mapper = new PropertyMapper<CustomMediaRouteButton, CustomMediaRouteButtonHandler>
        {
            // Add mappings here as needed
        };
        public CustomMediaRouteButtonHandler() : base(Mapper)
        {
        }
        protected override void ConnectHandler(MediaRouteButton platformView)
        {
            base.ConnectHandler(platformView);
            // Perform any setup that requires the PlatformView to be present
            SetEnabled(VirtualView.IsEnabled);
        }
        protected override MediaRouteButton CreatePlatformView()
        {
            var mediaRouteButton = new MediaRouteButton(Context);
            mediaRouteButton.Touch += OnMediaRouteButtonTouched;
            mediaRouteButton.Click += OnMediaRouteButtonClicked;
            SetEnabled(VirtualView.IsEnabled);
            return mediaRouteButton;
        }
        private void OnMediaRouteButtonTouched(object sender, AndroidViews.View.TouchEventArgs e)
        {
            // Handle touch events here
            // e.Event gives you access to the MotionEvent
            var oo = "";
        }

        private void OnMediaRouteButtonClicked(object sender, EventArgs e)
        {
            if (VirtualView != null)
            {
                VirtualView.OnClicked();
            }
        }

        protected override void DisconnectHandler(MediaRouteButton platformView)
        {
            platformView.Touch -= OnMediaRouteButtonTouched;
            platformView.Click -= OnMediaRouteButtonClicked;
            base.DisconnectHandler(platformView);
        }


        public static void MapIsEnabled(CustomMediaRouteButtonHandler handler, CustomMediaRouteButton customMediaRouteButton)
        {
            handler.SetEnabled(customMediaRouteButton.IsEnabled);
        }

        private void SetEnabled(bool isEnabled)
        {
            if (PlatformView != null)
            {
                PlatformView.Enabled = isEnabled;

                // Here you can adjust the visual state of the button,
                // like changing the opacity or text color, to indicate that it's disabled
                PlatformView.Alpha = isEnabled ? 1.0f : 0.5f;
            }
        }

        public void UpdateIsEnabled(bool isEnabled)
        {
            if (PlatformView != null)
            {
                PlatformView.Enabled = isEnabled;
                // Additional logic to update the visual state of the button
            }
        }
    }
}
