using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AnimationInListview.Model
{
    public class ParentItem : BindableBase
    {
        private string _someLabel;
        public string SomeLabel
        {
            get { return _someLabel; }
            set { SetProperty(ref _someLabel, value); }
        }

        private ObservableCollection<ChildItem> _childs;
        public ObservableCollection<ChildItem> Childs
        {
            get { return _childs; }
            set { SetProperty(ref _childs, value); }
        }
    }
}
