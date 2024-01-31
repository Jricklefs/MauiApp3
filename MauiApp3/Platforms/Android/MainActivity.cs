using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Cast.Framework;
using Android.Gms.Tasks;
using Android.OS;
using Java.Util.Concurrent;
using System.Threading.Tasks;

namespace MauiApp3
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Asynchronously initialize CastContext
            InitializeCastContextAsync(ApplicationContext);
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
                    // Do something with castContext...
                }
                else
                {
                    // Handle initialization failure
                    Exception exception = task.Exception;
                    // Log or display error...
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
    //castcontext.SetReceiverApplicationId("7AA05E47");
}
