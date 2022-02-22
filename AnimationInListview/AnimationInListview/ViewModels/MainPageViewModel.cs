using AnimationInListview.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AnimationInListview.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        private Random _random;


        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            _random = new Random();
            ParentItems = CreateObsCollection();
        }

        private ObservableCollection<ParentItem> _parentItems;
        public ObservableCollection<ParentItem> ParentItems
        {
            get { return _parentItems; }
            set { SetProperty(ref _parentItems, value); }
        }

        private static ObservableCollection<ParentItem> CreateObsCollection()
        {
            return new ObservableCollection<ParentItem>()
            {
                new ParentItem()
                {
                    SomeLabel = "Parent label 1",
                    Childs = new ObservableCollection<ChildItem>()
                    {
                        new ChildItem(){ SomeLabel = "Child p1-1"},
                        new ChildItem(){ SomeLabel = "Child p1-2"},
                        new ChildItem(){ SomeLabel = "Child p1-3"},
                    }
                },
                new ParentItem()
                {
                    SomeLabel = "Parent label 2",
                    Childs = new ObservableCollection<ChildItem>()
                    {
                        new ChildItem(){ SomeLabel = "Child p2-1"},
                        new ChildItem(){ SomeLabel = "Child p2-2"},
                        new ChildItem(){ SomeLabel = "Child p2-3"},
                    }
                },
                new ParentItem()
                {
                    SomeLabel = "Parent label 3",
                    Childs = new ObservableCollection<ChildItem>()
                    {
                        new ChildItem(){ SomeLabel = "Child p3-2"},
                        new ChildItem(){ SomeLabel = "Child p3-3"},
                        new ChildItem(){ SomeLabel = "Child p3-1"},
                    }
                },
                new ParentItem()
                {
                    SomeLabel = "Parent label 4",
                    Childs = new ObservableCollection<ChildItem>()
                    {
                        new ChildItem(){ SomeLabel = "Child p4-1"},
                        new ChildItem(){ SomeLabel = "Child p4-2"},
                        new ChildItem(){ SomeLabel = "Child p4-3"},
                    }
                },
            };
        }


        private DelegateCommand _rotateRandomChildCommand;
        public DelegateCommand RotateRandomChildCommand =>
            _rotateRandomChildCommand ?? (_rotateRandomChildCommand = new DelegateCommand(ExecuteRotateRandomChildCommand));

        void ExecuteRotateRandomChildCommand()
        {
            var child = GetRandomChild();
            _ = Device.InvokeOnMainThreadAsync(() =>
              {
                  child.AnimationInt = 1;
                  child.SomeLabel = $"{child.SomeLabel.Substring(0,10)} {DateTime.Now.ToLongTimeString()}";
              });
        }

        private DelegateCommand delegateCommand;
        public DelegateCommand FilterCollectionCommand =>
            delegateCommand ?? (delegateCommand = new DelegateCommand(ExecuteFilterCollectionCommand));

        void ExecuteFilterCollectionCommand()
        {
            var filtered = ParentItems.Take(2).ToList();

            _ = Device.InvokeOnMainThreadAsync(async () =>
            {
                foreach (var itemtoRemove in filtered)
                {
                    ParentItems.Remove(itemtoRemove);
                }


                foreach (var itemtoAdd in filtered)
                {
                    await System.Threading.Tasks.Task.Delay(500);
                    ParentItems.Insert(0, itemtoAdd);
                }
            });

        }

        private ChildItem GetRandomChild()
        {
            var elemIndex = _random.Next(ParentItems.Count);
            var elem = ParentItems[elemIndex];

            var childIndex = _random.Next(elem.Childs.Count);
            return elem.Childs[childIndex];
        }

    }
}
