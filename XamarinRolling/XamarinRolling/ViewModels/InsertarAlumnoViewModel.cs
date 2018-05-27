using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinRolling.Helpers;
using XamarinRolling.Models;
using XamarinRolling.ViewModels.Base;

namespace XamarinRolling.ViewModels
{
    public class InsertarAlumnoViewModel : ViewModelBase
    {
        public InsertarAlumnoViewModel()
        {
            this.Alumno = new Alumno();
        }

        private Alumno _Alumno;

        public Alumno Alumno
        {
            get { return this._Alumno; }
            set
            {
                this._Alumno = value;
                OnPropertyChanged("Alumno");
            }
        }

        HelperAutoescuelaAzure helper = new HelperAutoescuelaAzure();

        public Command InsertarAlumno
        {
            get
            {
                return new Command(async () => {
                    Alumno.Image = "avatar.png";
                    Alumno.Rol = "ALUMNO";                    
                    if (Alumno.Codigo == 0)
                    {
                        Alumno = null;
                    }
                    else
                    {
                        Alumno otro = await helper.GetAlumno(Alumno.Codigo);
                        if (otro != null)
                        {
                            Alumno = null;
                        }
                        else
                        {
                            await helper.CrearAlumno(this.Alumno);
                            await Application.Current.MainPage.Navigation.PopModalAsync();
                        }
                    }                                                         
                });
            }
        }
    }
}
