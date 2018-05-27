using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinRolling.Helpers;
using XamarinRolling.Models;
using XamarinRolling.ViewModels.Base;

namespace XamarinRolling.ViewModels
{
    public class AdministradorViewModel : ViewModelBase
    {
        private HelperAutoescuelaAzure helper;
        private Plantilla _Administrador;

        public AdministradorViewModel()
        {
            this.helper = new HelperAutoescuelaAzure();
        }

        public Plantilla Administrador
        {
            get { return this._Administrador; }
            set
            {
                this._Administrador = value;
                OnPropertyChanged("Administrador");

            }
        }

        public Command InsertarAdministrador
        {
            get
            {
                return new Command(async () =>
                {
                    //El método para crear un administrador es el mismo que para crear un profesor
                    //la diferencia es que al crear el administrador en la vista se tiene que poner
                    //Rol = ADMINISTRADOR de forma automática (Un entry ya con el parámetro no visible)
                    await helper.CrearProfesor(this.Administrador);
                });
            }
        }

        public Command ModificarAdministrador
        {
            get
            {
                return new Command(async () =>
                {
                    await helper.ModificarEmpleado(this.Administrador);
                    OnPropertyChanged("Administrador");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command EliminarAdministrador
        {
            get
            {
                return new Command(async () =>
                {
                    await helper.EliminarAdministrador(this.Administrador.Codigo);
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
