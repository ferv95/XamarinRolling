using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinRolling.Helpers;
using XamarinRolling.Models;
using XamarinRolling.ViewModels.Base;

namespace XamarinRolling.ViewModels
{
    public class PerfilViewModel : ViewModelBase
    {
        private HelperAutoescuelaAzure helper;
        private Plantilla _UsuarioPerfil;

        public PerfilViewModel()
        {
            this.helper = new HelperAutoescuelaAzure();
            Task.Run(async () =>
            {
                int id = int.Parse(App.Current.Id.ToString());
                this.UsuarioPerfil = await helper.GetEmpleado(id);
            });
        }

        public Plantilla UsuarioPerfil
        {
            get { return this._UsuarioPerfil; }
            set
            {
                this._UsuarioPerfil = value;
                OnPropertyChanged("UsuarioPerfil");
            }
        }

    }
}
