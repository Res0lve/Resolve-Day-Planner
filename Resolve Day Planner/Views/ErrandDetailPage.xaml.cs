using System.ComponentModel;
using Xamarin.Forms;
using ResolveDayPlanner.ViewModels;
using System;
using ResolveDayPlanner.Models;
using System.IO;
using ResolveDayPlanner.Services;

namespace ResolveDayPlanner.Views
{
    public partial class ErrandDetailPage : ContentPage
    {
        public ErrandDetailPage()
        {
            InitializeComponent();
            BindingContext = new ErrandDetailViewModel();
        }
    }
}