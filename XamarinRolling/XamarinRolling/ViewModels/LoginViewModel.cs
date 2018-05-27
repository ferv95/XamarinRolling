using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinRolling.Helpers;
using XamarinRolling.Models;
using XamarinRolling.ViewModels.Base;
using XamarinRolling.ViewModels;

namespace XamarinRolling.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        HelperAutoescuelaAzure helper;

        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Plantilla empleado = await helper.ExisteEmpleado(email, password);

                    if (empleado == null)
                    {
                        DisplayInvalidLoginPrompt();
                    }
                    else
                    {
                        DatosPerfil.CodPerfil = empleado.Codigo;
                        await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new Views.MainAutoescuelaView()));
                    }

                });
            }
        }

        public LoginViewModel()
        {
            helper = new HelperAutoescuelaAzure();
        }

    }
}
