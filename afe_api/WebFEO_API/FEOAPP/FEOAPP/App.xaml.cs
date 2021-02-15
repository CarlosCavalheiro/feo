using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FEOAPP.Services;
using FEOAPP.Views;
using FEOAPP.Style;

namespace FEOAPP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            //Altera entre o modo escuro/claro do app com base nas configurações do sistema
            VerificaThema(Application.Current.RequestedTheme);
            Application.Current.RequestedThemeChanged += (s, a) => { VerificaThema(a.RequestedTheme); };
        }

        public void VerificaThema(OSAppTheme currentTheme)
        {
            switch (currentTheme)
            {
                case OSAppTheme.Dark:
                    Current.Resources = new DarkTheme();
                    break;
                case OSAppTheme.Light:
                    Current.Resources = new LightTheme();
                    break;
                case OSAppTheme.Unspecified:
                    Current.Resources = new LightTheme();
                    break;
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
