using FEC_APP.Views.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FEC_APP.Services
{
    class Popup
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

        private static PopupAguarde popup;
        public static async void ExibirLoading()
        {
            if (popup == null)
                popup = new PopupAguarde();

            await PopupNavigation.Instance.PushAsync(popup, animate: true);

        }

        public static async void FecharLoading()
        {
            if (popup != null)
                await PopupNavigation.Instance.RemovePageAsync(popup);

        }
        public static async System.Threading.Tasks.Task ExibirAlerta(string mensagem)
        {
            PopupAlerta alerta = new PopupAlerta(mensagem);
            await PopupNavigation.Instance.PushAsync(alerta, animate: true);

        }
    }
}
