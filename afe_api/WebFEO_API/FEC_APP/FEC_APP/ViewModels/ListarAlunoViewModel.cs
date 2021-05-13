using FEC_APP.Models;
using FEC_APP.Services;
using FEC_APP.Views.Popup;
using PropertyChanged;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FEC_APP.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    class ListarAlunoViewModel
    {
        public List<Aluno> ListarAlunos { get; set; } = new List<Aluno>();

        public ListarAlunoViewModel()
        {
            CargaInicial();
            
        }

        public async void CargaInicial()
        {
            try
            {
                PopupAguarde aguarde = new PopupAguarde();
                await NavigationExtension.PushPopupAsync(null, aguarde);

                AlunoService service = new AlunoService();
                ListarAlunos = await service.Listar();

                await NavigationExtension.RemovePopupPageAsync(null, aguarde);
            }
            catch (Exception)
            {

                Toast.Show("Falha ao carregar lista de Alunos", Toast.ToastType.Error);

            }            

        }

    }
}
