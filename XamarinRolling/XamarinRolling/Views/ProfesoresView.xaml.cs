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
	public partial class ProfesoresView : ContentPage
	{
		public ProfesoresView ()
		{
			InitializeComponent ();
            this.entryBusqueda.TextChanged += EntryBusqueda_TextChanged;
        }

        private void EntryBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            string textoIntroducido = e.NewTextValue;
            ProfesoresViewModel viewModel = (ProfesoresViewModel)this.BindingContext;
            viewModel.Busqueda(textoIntroducido);
            
        }
    }
}