using FEOAPP.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FEOAPP.Services
{
    public static class Popup
    {
        public static async System.Threading.Tasks.Task<object> ExibirLoading(Func<System.Threading.Tasks.Task<object>> taskExecuteBackground)
        {
            PopupAguarde popupLoading = new PopupAguarde();

            object resultado = null;

            await PopupNavigation.Instance.PushAsync(popupLoading, animate: true);

            resultado = await popupLoading.BackgroundLoading(taskExecuteBackground);

            await popupLoading.PopupClosedTask;

            return resultado;

        }

        public static async System.Threading.Tasks.Task ExibirAlerta(string mensagem)
        {
            PopupAlerta alerta = new PopupAlerta(mensagem);

            //Abrir Painel de Assinatura
            await PopupNavigation.Instance.PushAsync(alerta, animate: true);
            //await alerta.PopupClosedTask;

        }
    }
}
