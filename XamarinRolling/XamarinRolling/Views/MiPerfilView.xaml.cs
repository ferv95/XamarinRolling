
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRolling.ViewModels;

namespace XamarinRolling.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MiPerfilView : ContentPage
	{
		public MiPerfilView ()
		{
			InitializeComponent ();
            //PerfilViewModel viewModel = new PerfilViewModel();
            if (this.imgimage.Source == null)
            {
                this.imgimage.Source = "avatar.png";
            }
           
        }
    }
}