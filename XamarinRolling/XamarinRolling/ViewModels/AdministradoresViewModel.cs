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
    public class AdministradoresViewModel : ViewModelBase
    {
        HelperAutoescuelaAzure helper;

        public AdministradoresViewModel()
        {
            helper = new HelperAutoescuelaAzure();
            Task.Run(async () => {
                List<Plantilla> lista = await helper.GetAdministradores();
                this.Administradores = new ObservableCollection<Plantilla>(lista);
            });
        }

        private ObservableCollection<Plantilla> _Administradores;
        

        public ObservableCollection<Plantilla> Administradores
        {
            get
            {
                return this._Administradores;
            }
            set
            {
                _Administradores = value;
                OnPropertyChanged("Administradores");
            }
        }

        private Plantilla _AdministradorSeleccionado;
        public Plantilla AdministradorSeleccionado
        {
            get { return this._AdministradorSeleccionado; }
            set
            {
                this._AdministradorSeleccionado = value;
                OnPropertyChanged("AdministradorSeleccionado");
            }
        }

        public Command DetallesAdministrador
        {
            get
            {
                return new Command(async () => {
                    if (AdministradorSeleccionado != null)
                    {
                        DetallesAdministrador detallesview = new DetallesAdministrador();
                        AdministradorViewModel viewmodeladministrador = new AdministradorViewModel();

                        viewmodeladministrador.Administrador = this.AdministradorSeleccionado;

                        detallesview.BindingContext = viewmodeladministrador;
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
                foreach (Plantilla p in this.Administradores)
                {
                    if (p.Apellido.ToUpper().Contains(filtro.ToUpper()))
                    {
                        listaFiltrada.Add(p);
                    }
                    if (p.Nombre.ToUpper().Contains(filtro.ToUpper()))
                    {
                        listaFiltrada.Add(p);
                    }
                }
                this.Administradores = listaFiltrada;
            }
            else
            {
                Task.Run(async () =>
                {
                    List<Plantilla> lista = await helper.GetAdministradores();
                    this.Administradores = new ObservableCollection<Plantilla>(lista);
                });
            }
        }

        public Command Nuevo
        {
            get
            {
                return new Command(async () => {
                    InsertarAdministradorView insertarview = new InsertarAdministradorView();
                    await Application.Current.MainPage.Navigation.PushModalAsync(insertarview);
                });
            }
        }
    }
}
