using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Windows.Input;
using ResolveDayPlanner.Models;
using ResolveDayPlanner.Services;
using Xamarin.Forms;
using ResolveDayPlanner.Views;

namespace ResolveDayPlanner.ViewModels
{
    public class NewErrandViewModel : BaseViewModel
    {
        private string errandtitle;
        private string description;
        private string priority;
        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "errand.xml");
        public NewErrandViewModel()
        {

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(errandtitle)
                && !String.IsNullOrWhiteSpace(description)
                && !String.IsNullOrWhiteSpace(priority);
        }

        public string ErrandTitle
        {
            get => errandtitle;
            set => SetProperty(ref errandtitle, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string Priority
        {
            get => priority;
            set => SetProperty(ref priority, value);

        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("//Main");
        }

        private async void OnSave()
        {

            if (!File.Exists(filePath))
            {
                var listErrand = new List<Errand>
                {
                    new Errand {Id = Guid.NewGuid().ToString(),
                    ErrandTitle = ErrandTitle,
                    Description = Description,
                    Priority = Priority}
                };

                XmlSerializerService.WriteToXmlFile(listErrand);
            }
            else
            {
                Errand objErrand = new Errand()
                {
                    Id = Guid.NewGuid().ToString(),
                    ErrandTitle = ErrandTitle,
                    Description = Description,
                    Priority = Priority
                };

                XmlSerializerService.AppendToXmlFile(objErrand);
            }
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("//Main");
        }
    }
}
