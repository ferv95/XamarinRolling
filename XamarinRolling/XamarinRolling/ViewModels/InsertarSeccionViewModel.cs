using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinRolling.Helpers;
using XamarinRolling.Models;
using XamarinRolling.ViewModels.Base;

namespace XamarinRolling.ViewModels
{
    public class InsertarSeccionViewModel : ViewModelBase
    {
        public InsertarSeccionViewModel()
        {
            this.Seccion = new Secciones();
        }

        private Secciones _Seccion;

        public Secciones Seccion
        {
            get { return this._Seccion; }
            set
            {
                this._Seccion = value;
                OnPropertyChanged("Seccion");
            }
        }

        HelperAutoescuelaAzure helper = new HelperAutoescuelaAzure();

        public Command InsertarSeccion
        {
            get
            {
                return new Command(async() => {
                    await helper.CrearSeccion(this.Seccion);
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }        
    }
}

