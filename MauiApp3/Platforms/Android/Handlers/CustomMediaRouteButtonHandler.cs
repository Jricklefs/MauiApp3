using Android.App;
using MauiApp3.CustomControls;
using Microsoft.Maui.Handlers;

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
            mediaRouteButton.Click += OnMediaRouteButtonClicked;
            return mediaRouteButton;
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
            platformView.Click -= OnMediaRouteButtonClicked;
            base.DisconnectHandler(platformView);
        }
    }
}
