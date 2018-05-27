using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinRolling.Helpers;
using XamarinRolling.Models;
using XamarinRolling.ViewModels.Base;

namespace XamarinRolling.ViewModels
{
    public class InsertarProfesorViewModel : ViewModelBase
    {
        public InsertarProfesorViewModel()
        {
            this.Profesor = new Plantilla();
        }

        private Plantilla _Profesor;

        public Plantilla Profesor
        {
            get { return this._Profesor; }
            set
            {
                this._Profesor = value;
                OnPropertyChanged("Profesor");
            }
        }

        HelperAutoescuelaAzure helper = new HelperAutoescuelaAzure();

        public Command InsertarProfesor
        {
            get
            {
                return new Command(async () => {
                    Profesor.Image = "avatar.png";
                    Profesor.Rol = "Profesor";
                    if (Profesor.Codigo == 0)
                    {
                        Profesor = null;
                    }
                    else
                    {
                        Plantilla otro = await helper.GetProfesor(Profesor.Codigo);
                        if (otro != null)
                        {
                            Profesor = null;
                        }
                        else
                        {
                            await helper.CrearProfesor(this.Profesor);
                            await Application.Current.MainPage.Navigation.PopModalAsync();
                        }
                    }
                });
            }
        }
    }
}
