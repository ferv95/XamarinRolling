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

        public PerfilViewModel(int id)
        {
            this.helper = new HelperAutoescuelaAzure();
            Task.Run(async () =>
            {
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
