using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Microsoft.Win32.SafeHandles;
using Xamarin.Forms;

namespace ResolveDayPlanner.ViewModels
{
    class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Action DisplayUserErrorPrompt;
        public Action DisplayPassErrorPrompt;
        public Action DisplayPassMatchErrorPrompt;
        public Action DisplayRegisterSuccessPrompt;
        public Action DisplayUnknownErrorPrompt;

        private int minLength = 4;

        public string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string newpassword;

        public string NewPassword
        {
            get { return newpassword; }
            set
            {
                newpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NewPassword"));
            }
        }
        public ICommand FinishRegisterCommand { protected set; get; }
        public ICommand CancelCommand { protected set; get; }

        public RegistrationViewModel()
        {
            FinishRegisterCommand = new Command(OnFinish);

            CancelCommand = new Command(OnCancel);
        }

        public async void OnFinish()
        {
            try
            {
                if (username.Length < minLength)
                {
                    DisplayUserErrorPrompt();
                }

                if (password.Length < minLength)
                {
                    DisplayPassErrorPrompt();
                }

                if (password != newpassword)
                {
                    DisplayPassMatchErrorPrompt();
                }

                if (!((username.Length < minLength) || (password.Length < minLength) || (password != newpassword)))
                {
                    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "login.txt");

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine(username);
                        writer.WriteLine(password);
                    }

                    DisplayRegisterSuccessPrompt();

                    await Shell.Current.GoToAsync("//Login");
                }    
            }
            catch(Exception)
            {
                DisplayUnknownErrorPrompt();
            }
        }

        public async void OnCancel()
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}
