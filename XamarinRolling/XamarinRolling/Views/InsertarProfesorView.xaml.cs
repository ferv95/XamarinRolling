﻿using System;
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
		public InsertarProfesorView ()
		{
			InitializeComponent ();
            txtseccion.Text = "SECCIÓN";
            txtcodigo.Text = "CÓDIGO";
        }
	}
}