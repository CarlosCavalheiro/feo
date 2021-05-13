using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FEC_APP.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupAguardePage : PopupPage
    {
        private TaskCompletionSource<bool> taskCompletionSource;
        public Task PopupClosedTask { get { return taskCompletionSource.Task; } }

        public PopupAguardePage()
        {
            Content = new StackLayout()
            {
                BackgroundColor = Color.Transparent,
                Children =
                {
                    new Label()
                    {
                        Text = "Carregando",
                        FontSize = 18,
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center
                    },
                    new ActivityIndicator()
                    {
                        IsRunning = true,
                        Color = Color.White
                    },
                },
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(10, 0, 10, 0),
            };

            // defina o plano de fundo para cores transparentes 
            // (Na verdade, transparência escurecida: observe o valor alfa no final)
            this.BackgroundColor = new Color(0, 0, 0, 0.4);

        }
        protected override bool OnBackButtonPressed()
        {
            return false;
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