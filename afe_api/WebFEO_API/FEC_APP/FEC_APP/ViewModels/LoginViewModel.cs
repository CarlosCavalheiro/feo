using FEC_APP.Models;
using FEC_APP.Services;
using FEC_APP.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FEC_APP.ViewModels
{
    public class LoginViewModel
    {

        public string Email { get; set; }
        public bool EmailError { get; set; }
        public string Senha { get; set; }
        public bool SenhaError { get; set; }

        public ICommand LoginCommand => new Command(async () => await Popup.ExibirLoading(() => RealizarLoginAsync()));

        async Task<object> RealizarLoginAsync()
        {

            this.EmailError = false;
            this.SenhaError = false;

            try
            {
                if (string.IsNullOrEmpty(Email) || !IsValidEmail(Email))
                    this.EmailError = true;
                if (string.IsNullOrEmpty(Senha))
                    this.SenhaError = true;

                if (!this.EmailError && !this.SenhaError)
                {
                    Usuario usuario = await Factory<UsuarioService>.GetInstance().Autenticar(Email, Senha);
                    if (usuario != null)
                    {
                        AppService.RegistrarLogin(ref usuario);
                        //usuario.CidadesAtendidas = await Factory<UsuarioService>.GetInstance().ListarCidades();
                        //AppService.RegistrarLogin(ref usuario);
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                        this.SenhaError = true;
                }
            }
            catch (Exception ex)
            {
                Toast.Show(ex.Message, Toast.ToastType.Error);
            }
            return null;

        }

        public LoginViewModel()
        {
            //LoginCommand = new Command(OnLoginClicked);
        }

        //private async void OnLoginClicked(object obj)
        //{
        //    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        //    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        //}

        //Valida E-MAIL
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


    }
}
