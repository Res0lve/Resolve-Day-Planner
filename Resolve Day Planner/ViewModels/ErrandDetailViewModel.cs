using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using ResolveDayPlanner.Views;

namespace ResolveDayPlanner.ViewModels
{
    [QueryProperty(nameof(ErrandId), nameof(ErrandId))]
    public class ErrandDetailViewModel : BaseViewModel 
    {
        public ErrandDetailViewModel()
        {
            List<Errand> errandList = XmlSerializerService.ReadFromXmlFile<List<Errand>>();

            FinishCommand = new Command(OnFinish);

            CancelCommand = new Command(OnCancel);
        }

        public Command FinishCommand { get; }
        public Command CancelCommand { get; }

        public string errandId;
        private string description;
        private string priority;
        public string Id { get; set; }

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
        public string ErrandId
        {
            get
            {
                return errandId;
            }
            set
            {
                errandId = value;
                LoadErrandId(value);
            }
        }


        public async void LoadErrandId(string errandId)
        {
            try
            {
                var errand = await ErrandDataStore.GetErrandAsync(errandId);
                Id = errand.Id;
                ErrandTitle = errand.ErrandTitle;
                Description = errand.Description;
                Priority = errand.Priority;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnFinish()
        {
            List<Errand> errandList = XmlSerializerService.ReadFromXmlFile<List<Errand>>();
            errandList.RemoveAll(errand => errand.Id == errandId);
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "errand.xml");
            File.Delete(filePath);
            XmlSerializerService.WriteToXmlFile(errandList);
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

