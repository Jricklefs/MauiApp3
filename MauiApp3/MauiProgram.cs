#if ANDROID
using MauiApp3.CustomControls;
using MauiApp3.Platforms.Android.Handlers;
#endif

using Microsoft.Extensions.Logging;

namespace MauiApp3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if ANDROID
            builder.ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddHandler<CustomMediaRouteButton, CustomMediaRouteButtonHandler>();
                });
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
