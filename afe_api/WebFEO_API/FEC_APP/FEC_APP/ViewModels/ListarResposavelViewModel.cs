using FEC_APP.Models;
using FEC_APP.Services;
using FEC_APP.Views.Popup;
using PropertyChanged;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FEC_APP.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    class ListarResponsavelViewModel
    {
        public List<Responsavel> ListarResponsavel { get; set; } = new List<Responsavel>();

        public ListarResponsavelViewModel()
        {
            CargaInicial();
        }

        public async void CargaInicial()
        {
            try
            {
                PopupAguarde aguarde = new PopupAguarde();
                await NavigationExtension.PushPopupAsync(null, aguarde);

                ResponsavelService service = new ResponsavelService();
                ListarResponsavel = await service.Listar();

                await NavigationExtension.RemovePopupPageAsync(null, aguarde);

            }
            catch (Exception)
            {

                Toast.Show("Falha ao carregar lista de responsáveis", Toast.ToastType.Error);

            }
           
        }

    }
}
