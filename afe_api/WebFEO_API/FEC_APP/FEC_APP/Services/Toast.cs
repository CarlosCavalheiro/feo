using Plugin.Toast;
using Plugin.Toast.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FEC_APP.Services
{
    public class Toast
    {
        public static void Show(string mensagem,
                                       ToastType tipo = ToastType.Info,
                                       ToastLength tempo = ToastLength.Short)
        {
            switch (tipo)
            {
                case ToastType.Error:
                    CrossToastPopUp.Current.ShowToastError(mensagem, tempo);
                    break;
                case ToastType.Info:
                    CrossToastPopUp.Current.ShowToastMessage(mensagem, tempo);
                    break;
                case ToastType.Success:
                    CrossToastPopUp.Current.ShowToastSuccess(mensagem, tempo);
                    break;
                case ToastType.Warning:
                    CrossToastPopUp.Current.ShowToastWarning(mensagem, tempo);
                    break;
            }
        }

        public enum ToastType
        {
            Warning = 1,
            Success = 2,
            Error = 3,
            Info = 4

        }
    }
}
