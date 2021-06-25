
using System;
using System.Collections.Generic;
using ResolveDayPlanner.ViewModels;
using Xamarin.Forms;

namespace ResolveDayPlanner.Views
{
    public partial class LoginPage : ContentPage
    {
        public Action DisplayInvalidLoginPrompt;
        public LoginPage()
        {
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again!", "OK");
            vm.DisplayRegisterPrompt += () => DisplayAlert("Error", "Please Register first!", "OK");
            vm.DisplayLoginPrompt += () => DisplayAlert("Error", "Already Registered, Please login!", "OK");
            vm.DisplayLoginSuccessPrompt += () => DisplayAlert("Access Granted", "Login was successful!", "OK");
            InitializeComponent();
        }
    }
}

