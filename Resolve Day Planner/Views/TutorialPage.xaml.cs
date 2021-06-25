using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResolveDayPlanner.Views
{
    public partial class TutorialPage : ContentPage
    {
        public TutorialPage()
        {
            InitializeComponent();

            Button tutorialButton = new Button
            {
                Text = "Start Tutorial!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            tutorialButton.Clicked += async (sender, args) => await DisplayAlert("Tutorial", "1. Click 'Start Day Planner' \n\n2. 'Add Task' is in the Top-Right Corner\n\n3. Click on individual task for more options \n\n4. N.B. SWIPE DOWN TO REFRESH PAGE", "OK");

            Button startButton = new Button
            {
                Text = "Start Day Planner!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            startButton.Clicked += async (sender, args) => await Shell.Current.GoToAsync("//Main");

            Content = new StackLayout
            {
                Children ={
                        tutorialButton, startButton
                    }
            };
        }
    }
}