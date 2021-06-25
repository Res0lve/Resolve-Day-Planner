using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ResolveDayPlanner.Models;
using ResolveDayPlanner.Views;
using ResolveDayPlanner.ViewModels;
using System.IO;
using ResolveDayPlanner.Services;
using System.Windows.Input;

namespace ResolveDayPlanner.Views
{
    public partial class ErrandPage : ContentPage
    {
        ErrandViewModel _viewModel;

        public List<Errand> loadErrands;
        public Command<Errand> ItemTapped { get; }
        public string Roboto { get; }
        public FontAttributes Bold { get; }

        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "errand.xml");

        public ErrandPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ErrandViewModel();

            if (!File.Exists(filePath))
            {
                List<Errand> loadErrands = null;
                listView.IsPullToRefreshEnabled = true;
                listView.ItemsSource = loadErrands;
                listView.ItemTemplate = new DataTemplate(typeof(ListCell)); // has context actions defined
            }
            else
            {
                List<Errand> loadErrands = XmlSerializerService.ReadFromXmlFile<List<Errand>>();
                listView.IsPullToRefreshEnabled = true;
                listView.ItemsSource = loadErrands;
                listView.ItemTemplate = new DataTemplate(typeof(ListCell)); // has context actions defined
            }

            listView.RefreshCommand = new Command(() =>
            {
                RefreshData();
                listView.IsRefreshing = false;
            });
        }

        public void RefreshData()
        {
            if (File.Exists(filePath))
            {
                List<Errand> loadErrands = XmlSerializerService.ReadFromXmlFile<List<Errand>>();
                listView.ItemsSource = null;
                listView.ItemsSource = loadErrands;
                listView.ItemTemplate = new DataTemplate(typeof(ListCell)); // has context actions defined
            }
        }

        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var errand = listView.SelectedItem as Errand;

            if (errand == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ErrandDetailPage)}?{nameof(ErrandDetailViewModel.ErrandId)}={errand.Id}");
        }

        void OnTap(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}