using FEC_APP.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace FEC_APP.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PrincipalViewModel
    {
        public string UsuarionNome => "Usuário Nome";
        public string UsuarioLogin => AppService.UsuarioRegistrado().Login;
        public string UsuarioTipo => AppService.UsuarioRegistrado().Tipo;

        public PrincipalViewModel()
        {

        }
        


    }
    
    
    
}
