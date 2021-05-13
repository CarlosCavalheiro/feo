using FEC_APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FEC_APP.Views.Docente
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoDocente : ContentPage
    {
        NovoDocenteViewModel viewModel;
        public NovoDocente(FEC_APP.Models.Docente docente)
        {
            viewModel = new NovoDocenteViewModel(docente);
            this.BindingContext = viewModel;
            InitializeComponent();

            if(docente !=null && docente.Id>0)
            {
                btnExcluir.IsVisible = true;
            }
        }

        private void clickedBtnExcluir(object sender, EventArgs e)
        {
            var result = DisplayAlert("Deseja realmente excluir a bomba?", "Sim", "Cancelar");

        }

        private void OnPreviousPageButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);

        }
    }
}