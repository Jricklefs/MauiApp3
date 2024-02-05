using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Cast;
using Android.Gms.Cast.Framework;
using Android.Gms.Tasks;
using Android.OS;
using Android.Util;
using AndroidX.MediaRouter.Media;
using Java.Util.Concurrent;
using MauiApp3.Platforms.Android.Services;

namespace MauiApp3
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public static MediaRouter MediaRouterInstance { get; private set; }
        public static MediaRouteSelector MediaRouteSelectorInstance { get; private set; }
        //private MyMediaRouterCallback _mediaRouterCallback;

        public static Context AppContext { get; private set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AppContext = ApplicationContext;

            InitializeCastContextAsync(AppContext);

            // Initialize MediaRouter and MediaRouteSelector
            MediaRouterInstance = MediaRouter.GetInstance(AppContext);
            MediaRouteSelectorInstance = new MediaRouteSelector.Builder()
                .AddControlCategory(CastMediaControlIntent.CategoryForCast("7AA05E47"))
                .Build();

            DependencyService.Register<IDeviceDiscoveryService, DeviceDiscoveryService>();
        }

        private void InitializeCastContextAsync(Context context)
        {
            // Define the executor
            IExecutor executor = AsyncTask.ThreadPoolExecutor;

            // Call the asynchronous method to get the CastContext instance
            Android.Gms.Tasks.Task castContextTask = CastContext.GetSharedInstance(context, executor);

            // Add a continuation task to handle completion
            castContextTask.AddOnCompleteListener(new OnCompleteListener(task =>
            {
                if (task.IsSuccessful)
                {
                    // CastContext is initialized
                    var castContext = (CastContext)task.Result;
                    Log.Debug("MainActivity", "CastContext initialized successfully.");
                }
                else
                {
                    // Handle initialization failure
                    Exception exception = task.Exception;
                    Log.Error("MainActivity", "Error initializing CastContext: " + exception);
                }
            }));

        }



        // Helper class to handle task completion
        public class OnCompleteListener : Java.Lang.Object, IOnCompleteListener
        {
            private readonly Action<Android.Gms.Tasks.Task> _onComplete;

            public OnCompleteListener(Action<Android.Gms.Tasks.Task> onComplete)
            {
                _onComplete = onComplete;
            }

            public void OnComplete(Android.Gms.Tasks.Task task)
            {
                _onComplete?.Invoke(task);
            }
        }





    }

}
