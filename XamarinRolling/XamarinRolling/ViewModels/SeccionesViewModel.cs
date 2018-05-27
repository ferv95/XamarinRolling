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
    public class SeccionesViewModel : ViewModelBase
    {
        HelperAutoescuelaAzure helper;

        public SeccionesViewModel()
        {
            helper = new HelperAutoescuelaAzure();
            Task.Run(async () =>
            {
                List<Secciones> lista = await helper.GetOficinas();
                this.Secciones = new ObservableCollection<Secciones>(lista);
            });
        }

        private ObservableCollection<Secciones> _Secciones;

        public ObservableCollection<Secciones> Secciones
        {
            get
            {
                return this._Secciones;
            }
            set
            {
                _Secciones = value;
                OnPropertyChanged("Secciones");
            }
        }

        private Secciones _SeccionSeleccionado;
        public Secciones SeccionSeleccionado
        {
            get { return this._SeccionSeleccionado; }
            set
            {
                this._SeccionSeleccionado = value;
                OnPropertyChanged("SeccionSeleccionado");
            }
        }

        public Command DetallesSeccion
        {
            get
            {
                return new Command(async () =>
                {
                    if (SeccionSeleccionado != null)
                    {
                        DetallesSeccion detallesview = new DetallesSeccion();
                        SeccionViewModel viewmodelseccion = new SeccionViewModel();

                        viewmodelseccion.Seccion = this.SeccionSeleccionado;

                        detallesview.BindingContext = viewmodelseccion;
                        await Application.Current.MainPage.Navigation.PushModalAsync(detallesview);
                    }
                    else
                    {
                        return;
                    }
                });
            }
        }

        public Command Nuevo
        {
            get
            {
                return new Command(async () => {
                    InsertarSeccionView insertarview = new InsertarSeccionView();
                    await Application.Current.MainPage.Navigation.PushModalAsync(insertarview);
                });
            }
        }
    }
}
