using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.CustomControls
{
    public class CustomMediaRouteButton : View
    {
        public event EventHandler Clicked;

        public void OnClicked() => Clicked?.Invoke(this, EventArgs.Empty);
    }
}
