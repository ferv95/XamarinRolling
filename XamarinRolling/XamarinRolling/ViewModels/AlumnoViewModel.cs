using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinRolling.Helpers;
using XamarinRolling.Models;
using XamarinRolling.ViewModels.Base;
using XamarinRolling.Views;

namespace XamarinRolling.ViewModels
{
    public class AlumnoViewModel : ViewModelBase
    {
        private HelperAutoescuelaAzure helper;
        private Alumno _Alumno;

        public AlumnoViewModel()
        {
            this.helper = new HelperAutoescuelaAzure();
        }

        public Alumno Alumno
        {
            get { return this._Alumno; }
            set
            {
                this._Alumno = value;
                OnPropertyChanged("Alumno");
            }
        }

        public Command InsertarAlumno
        {
            get
            {
                return new Command(async () => {
                    await helper.CrearAlumno(this.Alumno);
                });
            }
        }

        public Command ModificarAlumno
        {
            get
            {
                return new Command(async () => {
                    await helper.ModificarAlumno(this.Alumno);
                    OnPropertyChanged();
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command EliminarAlumno
        {
            get
            {
                return new Command(async () => {
                    await helper.EliminarAlumno(this.Alumno.Codigo);
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        
    }
}
