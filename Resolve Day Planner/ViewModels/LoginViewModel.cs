using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using ResolveDayPlanner.Views;
using System.IO;
using System.Threading.Tasks;

namespace ResolveDayPlanner.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public Action DisplayLoginSuccessPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "login.txt");

        private string username;
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
        public ICommand LoginCommand { protected set; get; }
        public ICommand RegisterCommand { protected set; get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);

            RegisterCommand = new Command(OnRegister);
        }
        public async void OnLogin()
        {
            if (!File.Exists(filePath))
            {
                DisplayRegisterPrompt();
            }
            else
            {
                string[] credentials = File.ReadAllLines(filePath);

                if (username == credentials[0] && password == credentials[1])
                {
                    DisplayLoginSuccessPrompt();
                    await Shell.Current.GoToAsync("//Login/Tutorial");
                };

                if (username != credentials[0] || password != credentials[1])
                {
                    DisplayInvalidLoginPrompt();
                };
            }
        }
        public async void OnRegister()
        {
            if (File.Exists(filePath))
            {
                DisplayLoginPrompt();
            } 
       
        }
    }
}
