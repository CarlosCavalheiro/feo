using FEC_APP.Models;
using FEC_APP.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

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
            DocenteService service = new DocenteService();
            ListarDocente = await service.Listar();
        }

    }
}
