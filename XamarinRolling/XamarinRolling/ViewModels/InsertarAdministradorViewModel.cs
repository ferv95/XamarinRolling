using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinRolling.Helpers;
using XamarinRolling.Models;
using XamarinRolling.ViewModels.Base;

namespace XamarinRolling.ViewModels
{
    public class InsertarAdministradorViewModel : ViewModelBase
    {
        public InsertarAdministradorViewModel()
        {
            this.Administrador = new Plantilla();
        }

        private Plantilla _Administrador;

        public Plantilla Administrador
        {
            get { return this._Administrador; }
            set
            {
                this._Administrador = value;
                OnPropertyChanged("Administrador");
            }
        }

        HelperAutoescuelaAzure helper = new HelperAutoescuelaAzure();

        public Command InsertarAdministrador
        {
            get
            {
                return new Command(async () => {
                    Administrador.Image = "avatar.png";
                    Administrador.Rol = "ADMINISTRACION";
                    if (Administrador.Codigo == 0)
                    {
                        Administrador = null;
                    }
                    else
                    {
                        Plantilla otro = await helper.GetAdministrador(Administrador.Codigo);
                        if (otro != null)
                        {
                            Administrador = null;
                        }
                        else
                        {
                            await helper.CrearProfesor(this.Administrador);
                            await Application.Current.MainPage.Navigation.PopModalAsync();
                        }
                    }
                });
            }
        }
    }
}
