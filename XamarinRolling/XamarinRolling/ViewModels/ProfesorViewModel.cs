using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinRolling.Helpers;
using XamarinRolling.Models;
using XamarinRolling.ViewModels.Base;

namespace XamarinRolling.ViewModels
{
    public class ProfesorViewModel : ViewModelBase
    {
        private HelperAutoescuelaAzure helper;
        private Plantilla _Profesor;

        public ProfesorViewModel()
        {
            this.helper = new HelperAutoescuelaAzure();
        }

        public Plantilla Profesor
        {
            get { return this._Profesor; }
            set
            {
                this._Profesor = value;
                OnPropertyChanged("Profesor");
            }
        }

        public Command InsertarProfesor
        {
            get
            {
                return new Command(async () =>
                {
                    await helper.CrearProfesor(this.Profesor);
                });
            }
        }

        public Command ModificarProfesor
        {
            get
            {
                return new Command(async () =>
                {
                    await helper.ModificarEmpleado(this.Profesor);
                    OnPropertyChanged("Profesor");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command EliminarProfesor
        {
            get
            {
                return new Command(async () =>
                {
                    await helper.EliminarProfesor(this.Profesor.Codigo);
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

    }
}
