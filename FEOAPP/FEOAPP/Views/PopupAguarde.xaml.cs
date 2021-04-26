using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FEOAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupAguarde : PopupPage
    {
        private TaskCompletionSource<bool> taskCompletionSource;
        public Task PopupClosedTask { get { return taskCompletionSource.Task; } }

        public PopupAguarde()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        public async Task<object> BackgroundLoading(Func<Task<object>> taskBackground)
        {

            var resultado = await taskBackground();

            await PopupNavigation.Instance.RemovePageAsync(this, animate: true);

            return resultado;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            taskCompletionSource = new TaskCompletionSource<bool>();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            taskCompletionSource.SetResult(true);
        }
    }
}