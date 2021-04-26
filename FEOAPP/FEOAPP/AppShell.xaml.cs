using System;
using System.Collections.Generic;
using FEOAPP.ViewModels;
using FEOAPP.Views;
using Xamarin.Forms;

namespace FEOAPP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnSairClicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("SAIR?", "Deseja realmente sair o aplicativo?", "OK", "Cancelar");
            if(result)
                await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "0");

            Application.Current.MainPage = new NavigationPage(new LoginPage());
            await Application.Current.MainPage.Navigation.PopToRootAsync();
            //await Navigation.PopToRootAsync(false);

        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("//LoginPage");
        //}
    }
}
