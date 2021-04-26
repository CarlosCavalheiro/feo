using FEOAPP.Models;
using FEOAPP.Services;
using FEOAPP.Views;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FEOAPP.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : BaseViewModel
    {
        //public Command LoginCommand { get; }

        #region Propriedades
        public string Login { get; set; }
        public bool LoginError { get; set; }
        public string Senha { get; set; }
        public bool SenhaError { get; set; }
        #endregion
        
        public ICommand LoginCommand => new Command(async () => await Popup.ExibirLoading(() => RealizarLoginAsync()));
        //public ICommand AbrirMenuCommand => new Command(async () => await Popup.ExibirLoading(() => OnLoginClicked()));



        public LoginViewModel()
        {
            //LoginCommand = new Command(OnLoginClicked);
        }

        async Task<object> RealizarLoginAsync()
        {
            await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
            Application.Current.MainPage = new AppShell();
            //await Shell.Current.GoToAsync("//AppShell");
            return null;
        }
        

        //private async void OnLoginClicked(object obj)
        //{
        //    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        //    await Shell.Current.GoToAsync($"//{nameof(Principal)}");
        //}

        //async Task<object> RealizarLoginAsync()
        //{

        //    this.LoginError = false;
        //    this.SenhaError = false;

        //    try
        //    {
        //        if (string.IsNullOrEmpty(Login) || !RegexUtilities.IsValidEmail(Login))
        //            this.LoginError = true;
        //        if (string.IsNullOrEmpty(Senha))
        //            this.SenhaError = true;

        //        if (!this.LoginError && !this.SenhaError)
        //        {
        //            Usuario usuario = await Factory<Services.UsuarioService>.GetInstance().CarregaLogin(Login, Senha);
        //            if (usuario != null)    
        //            {
        //                AppService.RegistrarLogin(ref usuario);
        //                Application.Current.MainPage = new AppShell();
        //            }
        //            else
        //                this.SenhaError = true;
        //        }
        //        else
        //        {
        //            Toast.Show("Verifique seu usuário/senha se foram preenchidos!", Toast.ToastType.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Toast.Show(ex.Message, Toast.ToastType.Error);
        //    }
        //    //await NavigationExtension.RemovePopupPageAsync(null, loadingPage);
        //    //await Navigation.PushPopupAsync(new LoginSuccessPopupPage());
        //    return null;

        //}
    }
}
