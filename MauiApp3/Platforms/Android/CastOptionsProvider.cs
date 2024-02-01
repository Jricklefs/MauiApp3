using Android.Content;
using Android.Gms.Cast.Framework;
using Android.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MauiApp3.Platforms.Android
{
    [Register("MauiApp3/CastOptionsProvider")]
    public class CastOptionsProvider : Java.Lang.Object, IOptionsProvider
    {
        public CastOptions GetCastOptions(Context appContext)
        {
            var options = new CastOptions.Builder()
                .SetReceiverApplicationId("7AA05E47")
                .Build();

            return options;
        }

        public IList<SessionProvider> GetAdditionalSessionProviders(Context appContext)
        {
            return null;
        }
    }
}
