using FEC_APP.Models;
using FEC_APP.Services;
using PropertyChanged;
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
            AlunoService service = new AlunoService();
            ListarAlunos = await service.Listar();
        }

    }
}
