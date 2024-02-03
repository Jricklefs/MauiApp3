using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if(ANDROID)
using MauiApp3.Platforms.Android.Handlers;
#endif

namespace MauiApp3.CustomControls
{
    public class CustomMediaRouteButton : View
    {
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(
                nameof(IsEnabled), typeof(bool), typeof(CustomMediaRouteButton), true, propertyChanged: OnIsEnabledChanged);

        public event EventHandler Clicked;

        public bool IsEnabled
        {
            get => (bool)GetValue(IsEnabledProperty);
            set => SetValue(IsEnabledProperty, value);
        }

        public void OnClicked()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }

        private static void OnIsEnabledChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (CustomMediaRouteButton)bindable;
            (view.Handler as CustomMediaRouteButtonHandler)?.UpdateIsEnabled((bool)newValue);
        }

    }
}
