using FEC_APP.ViewModels;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FEC_APP.Views.Docente
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [AddINotifyPropertyChangedInterface]

    public partial class ListarDocente : ContentPage
    {
        public ListarDocente()
        {
            InitializeComponent();
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync(nameof(NovoDocente));
            await Navigation.PushModalAsync(new NovoDocente(null), true);

        }

        private void OnClickedEditarDocente(object sender, EventArgs e)
        {
            ((ListarDocenteViewModel)this.BindingContext).DocenteSelecionado(Convert.ToInt64(((Button)sender).CommandParameter));

        }
    }
}