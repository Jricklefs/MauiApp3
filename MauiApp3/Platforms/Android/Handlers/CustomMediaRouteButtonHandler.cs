using Android.App;
using MauiApp3.CustomControls;
using Microsoft.Maui.Handlers;
using static Android.Views.View;
using AndroidViews = Android.Views;
using AU = Android.Util;

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
            mediaRouteButton.SetOnClickListener(new CustomClickListener());
            return mediaRouteButton;
        }

        private class CustomClickListener : Java.Lang.Object, AndroidViews.View.IOnClickListener
        {
            public void OnClick(AndroidViews.View? v)
            {
                //((MediaRouteButton)v).PerformClick();
                // Log the click event
                AU.Log.Debug("CustomMediaRouteButton", "Button clicked.");

                // Optionally perform additional actions here
                // If you want to show the dialog manually, you could invoke it here,
                // but only if it doesn't get automatically shown by the MediaRouteButton itself.

                // If the dialog does not automatically show, you can try to invoke it here manually.
                // However, if the dialog is automatically shown by the MediaRouteButton, you should
                // NOT call ShowDialog() here as it may interfere with the button's default behavior.
             
            }
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
            //isEnabled = true;
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
                PlatformView.Alpha = isEnabled ? 1.0f : 0.5f;

               
            }
        }
    }
}
