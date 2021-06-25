using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;


using ResolveDayPlanner.Models;
using ResolveDayPlanner.Views;
using System.Collections.Generic;
using ResolveDayPlanner.Services;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace ResolveDayPlanner.ViewModels
{
    public class ErrandViewModel : BaseViewModel 
    {
        public Command AddErrandCommand { get; }
        public Command<Errand> ErrandTapped { get; }

        public List<Errand> errands;

        public ErrandViewModel()
        {

            AddErrandCommand = new Command(OnAddErrand);

            ErrandTapped = new Command<Errand>(OnErrandSelected);
        }

        private async void OnAddErrand(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewErrandPage));
        }
        async void OnErrandSelected(Errand errand)
        {
            if (errand == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ErrandDetailPage)}?{nameof(ErrandDetailViewModel.ErrandId)}={errand.Id}");
        }

    }
}