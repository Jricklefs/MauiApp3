using Android.App;
using Android.Content;
using MauiApp3.CustomControls;
using MauiApp3.Platforms.Android.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;


[assembly: ExportRenderer(typeof(MauiApp3.CustomControls.CustomMediaRouteButton), typeof(MauiApp3.Platforms.Android.Controls.CustomMediaRouteButtonRenderer))]
namespace MauiApp3.Platforms.Android.Controls
{
    public class CustomMediaRouteButtonRenderer : ViewRenderer<CustomMediaRouteButton, MediaRouteButton>
    {
        public CustomMediaRouteButtonRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<CustomMediaRouteButton> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                MediaRouteButton mediaRouteButton = new MediaRouteButton(Context);
                // Configure the button as needed
                SetNativeControl(mediaRouteButton);
            }
        }
    }
}
