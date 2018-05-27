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
    public class ProfesoresViewModel : ViewModelBase
    {
        HelperAutoescuelaAzure helper;

        public ProfesoresViewModel()
        {
            helper = new HelperAutoescuelaAzure();
            Task.Run(async () => {
                List<Plantilla> lista = await helper.GetProfesores();
                this.Profesores = new ObservableCollection<Plantilla>(lista);
                //foreach (var e in Profesores)
                //{
                //    if(e.Image == null)
                //    {
                //        e.Image = "avatar.png";
                //    }
                //}
            });
        }

        private ObservableCollection<Plantilla> _Profesores;

        public ObservableCollection<Plantilla> Profesores
        {
            get
            {
                return this._Profesores;
            }
            set
            {
                _Profesores = value;
                OnPropertyChanged("Profesores");
            }
        }

        private Plantilla _ProfesorSeleccionado;
        public Plantilla ProfesorSeleccionado
        {
            get { return this._ProfesorSeleccionado; }
            set
            {
                this._ProfesorSeleccionado = value;
                OnPropertyChanged("ProfesorSeleccionado");
            }
        }

        public Command DetallesProfesor
        {
            get
            {
                return new Command(async () => {
                    if (ProfesorSeleccionado != null)
                    {
                        DetallesProfesor detallesview = new DetallesProfesor();
                        ProfesorViewModel viewmodelProfesor = new ProfesorViewModel();
                        
                        viewmodelProfesor.Profesor = this.ProfesorSeleccionado;

                        detallesview.BindingContext = viewmodelProfesor;
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
                ObservableCollection<Plantilla> listaFiltrada = new ObservableCollection<Plantilla>();
                foreach (Plantilla p in this.Profesores)
                {
                    if (p.Apellido.ToUpper().Contains(filtro.ToUpper()))
                    {
                        listaFiltrada.Add(p);
                    }
                }
                this.Profesores = listaFiltrada;
            }
            else
            {
                Task.Run(async () =>
                {
                    List<Plantilla> lista = await helper.GetProfesores();
                    this.Profesores = new ObservableCollection<Plantilla>(lista);
                });
            }
        }
    }

}

