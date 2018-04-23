using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;

namespace ListViewBehaviors.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isLoadingMore;
        public MainViewModel()
        {
            Items = new ObservableCollection<Item>();
            ItemSelectedCommand = new RelayCommand<Item>(ItemSelected);
            LoadMoreCommand = new RelayCommand(LoadMore);

            for (int i = 0; i < 10; i++)
            {
                Items.Add(new Item() { Value = $"Item {i}" });
            }
        }

        public ObservableCollection<Item> Items { get; private set; }

        public bool IsLoadingMore
        {
            get { return _isLoadingMore; }
            set { Set(ref _isLoadingMore, value); }
        }

        protected void ItemSelected(Item item)
        {
            Console.WriteLine($"item selected {item.Value}");
        }

        public RelayCommand LoadMoreCommand
        {
            get; private set;
        }
        public RelayCommand<Item> ItemSelectedCommand
        {
            get; private set;
        }

        public void LoadMore()
        {
            if (!IsLoadingMore)
            {
                IsLoadingMore = true;
                for (int i = 0; i < 10; i++)
                {
                    Items.Add(new Item() { Value = $"Item {i}" });
                }
                IsLoadingMore = false;
            }
        }
    }

    public class Item
    {
        public string Value { get; set; }
    }
}
