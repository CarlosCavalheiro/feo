using FEC_APP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FEC_APP.Services
{
    public class AppService
    {
        private const string USUARIO_APP = "_usuario_app";
        public static void RegistrarLogin(ref Usuario usuario)
        {
            if (Application.Current.Properties.ContainsKey(USUARIO_APP))
                Application.Current.Properties[USUARIO_APP] = usuario;
            else
                Application.Current.Properties.Add(USUARIO_APP, usuario);
        }

        public static Usuario UsuarioRegistrado()
        {
            return (Usuario)Application.Current.Properties[USUARIO_APP];
        }
    }
}
