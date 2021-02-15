using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FEOAPP.Style
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Base : ResourceDictionary
    {
        public Base()
        {
            InitializeComponent();
        }
    }
}