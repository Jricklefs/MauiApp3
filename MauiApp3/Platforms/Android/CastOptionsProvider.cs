using Android.Content;
using Android.Gms.Cast.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MauiApp3.Platforms.Android
{
    public class CastOptionsProvider : Java.Lang.Object, IOptionsProvider
    {
        public CastOptions GetCastOptions(Context appContext)
        {
            var options = new CastOptions.Builder()
                .SetReceiverApplicationId("XXX05E47")
                .Build();

            return options;
        }

        //public IPackageChannel GetCastChannel(string channelId)
        //{
        //    return null;
        //}

        public IList<SessionProvider> GetAdditionalSessionProviders(Context appContext)
        {
            return null;
        }
    }
}
