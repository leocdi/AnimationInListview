using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AnimationInListview.Controls
{
    public class AnimatedGrid : Grid
    {
        public static readonly BindableProperty RefreshProperty =
            BindableProperty.Create(nameof(Refresh), typeof(int), typeof(ViewCell), 0, BindingMode.TwoWay);

        public int Refresh
        {
            get { return (int)GetValue(RefreshProperty); }
            set { SetValue(RefreshProperty, value); }
        }


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(Refresh))
            {
                switch (Refresh)
                {
                    case 1:
                        Device.InvokeOnMainThreadAsync(() => this.RelRotateTo(360, 400));
                        break;
                    case 2:
                        Device.InvokeOnMainThreadAsync(() => this.RelRotateTo(-360, 400));
                        break;
                }
                if (Refresh != 0) Refresh = 0;
            }


        }
    }
}
