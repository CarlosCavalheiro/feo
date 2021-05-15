using FEC_APP.Models;
using FEC_APP.Services;
using FEC_APP.Views.Docente;
using FEC_APP.Views.Popup;
using PropertyChanged;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FEC_APP.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    class ListarDocenteViewModel
    {
        public List<Docente> ListarDocente { get; set; } = new List<Docente>();

        public ListarDocenteViewModel()
        {
            CargaInicial();
        }

        public async void CargaInicial()
        {
            try
            {
                PopupAguarde aguarde = new PopupAguarde();
                await NavigationExtension.PushPopupAsync(null, aguarde);

                DocenteService service = new DocenteService();
                ListarDocente = await service.Listar();

                await NavigationExtension.RemovePopupPageAsync(null, aguarde);
            }
            catch (Exception)
            {

                Toast.Show("Falha ao carregar lista de docentes", Toast.ToastType.Error);

            }


        }

        public async void DocenteSelecionado(long id)
        {
            try
            {
                Docente _docente = this.ListarDocente.Find(x => x.Id == id);
                NovoDocente pagina = new NovoDocente(_docente);
                await Application.Current.MainPage.Navigation.PushModalAsync(pagina, true);
            }
            catch (Exception ex)
            {

                Toast.Show($"Falha ao localizar Docente. {ex.Message}");
            }
        }


    }
}
