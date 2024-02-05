
using AndroidX.MediaRouter.App;
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

        protected override MediaRouteButton CreatePlatformView()
        {
            var mediaRouteButton = new MediaRouteButton(Context);
            mediaRouteButton.RouteSelector = MainActivity.MediaRouteSelectorInstance;
            return mediaRouteButton;
        }


        //private void SetEnabled(bool isEnabled)
        //{
        //    //isEnabled = true;
        //    if (PlatformView != null)
        //    {
        //        PlatformView.Enabled = isEnabled;
        //        // Here you can adjust the visual state of the button,
        //        // like changing the opacity or text color, to indicate that it's disabled
        //        PlatformView.Alpha = isEnabled ? 1.0f : 0.5f;
        //    }
        //}

        public void UpdateIsEnabled(bool isEnabled)
        {
            if (PlatformView != null)
            {
                PlatformView.Enabled = isEnabled;
                // Additional logic to update the visual state of the button
               // PlatformView.Alpha = isEnabled ? 1.0f : 0.5f;
            }
        }
    }
}
