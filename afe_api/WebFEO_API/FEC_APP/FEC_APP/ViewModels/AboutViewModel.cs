using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FEC_APP.ViewModels
{
    public class AboutViewModel
    {
        public string Title { get; set; }
        public AboutViewModel()
        {
            Title = "Sobre o FEC";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}