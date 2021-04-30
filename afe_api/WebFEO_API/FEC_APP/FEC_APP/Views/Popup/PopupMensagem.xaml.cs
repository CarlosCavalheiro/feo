using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FEC_APP.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupMensagem : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupMensagem(string titulo = "Atenção", string mensagem = "Aguarde...")
        {
            InitializeComponent();
            lblTitulo.Text = titulo;
            lblMensagem.Text = mensagem;
        }
        private async void OnClose(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

    }
}