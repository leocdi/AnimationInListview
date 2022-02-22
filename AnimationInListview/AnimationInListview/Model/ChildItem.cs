using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimationInListview.Model
{
    public class ChildItem : BindableBase
    {
        private string _someLabel;
        public string SomeLabel
        {
            get { return _someLabel; }
            set { SetProperty(ref _someLabel, value); }
        }

        private int _animationInt;
        public int AnimationInt
        {
            get { return _animationInt; }
            set { SetProperty(ref _animationInt, value); }
        }
    }
}
