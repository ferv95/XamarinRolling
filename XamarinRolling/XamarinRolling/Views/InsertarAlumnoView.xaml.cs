using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRolling.ViewModels;

namespace XamarinRolling.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InsertarAlumnoView : ContentPage
	{
		public InsertarAlumnoView ()
		{
			InitializeComponent ();
            txtseccion.Text = "";
            txtcodigo.Text = "";
            txtpass.Text = "";
            txtrepass.Text = "";
            txttelefono.Text = "";
            txtrepass.PropertyChanged += Txtpass_PropertyChanged;

        }

        private void Txtpass_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (txtrepass.Text != txtpass.Text)
            {
                btninsertar.IsEnabled = false;
                txterror.IsVisible = true;
            }
            else
            {
                btninsertar.IsEnabled = true;
                txterror.IsVisible = false;
            }
               
        }
    }
}