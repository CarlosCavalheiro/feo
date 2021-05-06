using FEC_APP.Models;
using FEC_APP.Services;
using PropertyChanged;
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
            ResponsavelService service = new ResponsavelService();
            ListarResponsavel = await service.Listar();
        }

    }
}
