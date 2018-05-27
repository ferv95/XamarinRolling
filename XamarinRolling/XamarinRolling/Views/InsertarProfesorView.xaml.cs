using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinRolling.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertarProfesorView : ContentPage
    {
        public InsertarProfesorView()
        {
            InitializeComponent();
            txtcodigo.Text = "";
            txttelef.Text = "";
            txtpass.Text = "";
            txtrepass.Text = "";
            txtrepass.PropertyChanged += Txtrepass_PropertyChanged;
        }

        private void Txtrepass_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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