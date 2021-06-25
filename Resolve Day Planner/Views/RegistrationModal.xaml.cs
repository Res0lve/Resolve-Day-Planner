using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveDayPlanner.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResolveDayPlanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationModal : ContentPage
    {
        public RegistrationModal()
        {
            var vm = new RegistrationViewModel();
            this.BindingContext = vm;
            vm.DisplayUserErrorPrompt += () => DisplayAlert("Error", "Username must be more than 4 characters!", "OK");
            vm.DisplayPassErrorPrompt += () => DisplayAlert("Error", "Password must be more than 4 characters!", "OK");
            vm.DisplayPassMatchErrorPrompt += () => DisplayAlert("Error", "Passwords must match!", "OK");
            vm.DisplayRegisterSuccessPrompt += () => DisplayAlert("Registration Complete", "Registration was successful!", "OK");
            vm.DisplayUnknownErrorPrompt += () => DisplayAlert("Error", "Unknown Error!", "OK");
            InitializeComponent();
        }
    }
}