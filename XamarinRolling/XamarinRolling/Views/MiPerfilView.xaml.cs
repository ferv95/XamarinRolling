
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
            PerfilViewModel viewModel = (PerfilViewModel)BindingContext;
            if (viewModel.UsuarioPerfil.Image == null)
            {
                viewModel.UsuarioPerfil.Image = "avatar.png";
            }
		}
	}
}