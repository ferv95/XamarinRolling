
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinRolling.Helpers;
using XamarinRolling.Models;
using System.Threading.Tasks;

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

        public ICommand SubmitCommand { protected set; get; }

        public LoginViewModel()
        {
            helper = new HelperAutoescuelaAzure();

            SubmitCommand = new Command(OnSubmit);
        }

        public void OnSubmit()
        {
            Plantilla empleado = new Plantilla();

            Task.Run(async () =>
            {
                empleado = await helper.ExisteEmpleado(email, password);

            });

            if (empleado.Usuario == null)
            {
                DisplayInvalidLoginPrompt();
            }

        }
    }
}