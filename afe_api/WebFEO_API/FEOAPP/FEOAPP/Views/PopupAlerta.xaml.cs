using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FEOAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupAlerta : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupAlerta(string mensagem = "Aguarde...")
        {
            InitializeComponent();
            lblMensagemAguarde.Text = mensagem;
        }
        private async void OnClose(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

    }
}