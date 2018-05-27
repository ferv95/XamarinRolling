using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinRolling.Helpers;
using XamarinRolling.Models;
using XamarinRolling.ViewModels.Base;
using XamarinRolling.Views;

namespace XamarinRolling.ViewModels
{
    public class AlumnosViewModel : ViewModelBase
    {
        HelperAutoescuelaAzure helper;


        public AlumnosViewModel()
        {
            helper = new HelperAutoescuelaAzure();
            Task.Run(async () =>
            {
                List<Alumno> lista = await helper.GetAlumnos();
                this.Alumnos = new ObservableCollection<Alumno>(lista);
            });
        }

        private ObservableCollection<Alumno> _Alumnos;

        public ObservableCollection<Alumno> Alumnos
        {
            get
            {
                return this._Alumnos;
            }
            set
            {
                _Alumnos = value;
                OnPropertyChanged("Alumnos");
            }
        }

        private Alumno _AlumnoSeleccionado;
        public Alumno AlumnoSeleccionado
        {
            get { return this._AlumnoSeleccionado; }
            set
            {
                this._AlumnoSeleccionado = value;
                OnPropertyChanged("AlumnoSeleccionado");
            }
        }




        public Command DetallesAlumno
        {
            get
            {
                return new Command(async () =>
                {
                    if (AlumnoSeleccionado != null)
                    {
                        DetallesAlumno detallesview = new DetallesAlumno();
                        AlumnoViewModel viewmodelalumno = new AlumnoViewModel();

                        viewmodelalumno.Alumno = this.AlumnoSeleccionado;

                        detallesview.BindingContext = viewmodelalumno;
                        await Application.Current.MainPage.Navigation.PushModalAsync(detallesview);
                    }
                    else
                    {
                        return;
                    }
                });
            }
        }

        public void Busqueda(string filtro)
        {
            if (filtro.Length > 0)
            {
                ObservableCollection<Alumno> listaFiltrada = new ObservableCollection<Alumno>();
                foreach (Alumno p in this.Alumnos)
                {
                    if (p.Apellidos.ToUpper().Contains(filtro.ToUpper()))
                    {
                        listaFiltrada.Add(p);
                    }
                }
                this.Alumnos = listaFiltrada;
            }
            else
            {
                Task.Run(async () =>
                {
                    List<Alumno> lista = await helper.GetAlumnos();
                    this.Alumnos = new ObservableCollection<Alumno>(lista);
                });
            }
        }

        public Command Nuevo
        {
            get
            {
                return new Command(async () => {
                    InsertarAlumnoView insertarview = new InsertarAlumnoView();
                    await Application.Current.MainPage.Navigation.PushModalAsync(insertarview);
                });
            }
        }
    }
}
