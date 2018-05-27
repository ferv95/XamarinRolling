using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRolling.Models;

namespace XamarinRolling.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainAutoescuelaView : MasterDetailPage
    {
        public List<MasterPageItem> menu { get; set; }
        public MainAutoescuelaView()
        {
            InitializeComponent();
            menu = new List<MasterPageItem>();
            var miperfilview = new MasterPageItem()
            {
                Titulo = "Mi Perfil",
                PaginaHija = typeof(MiPerfilView)
            };
            var alumnosview = new MasterPageItem()
            {
                Titulo = "Alumnos"
                ,
                PaginaHija = typeof(AlumnosView)
            };
            var profesoresview = new MasterPageItem()
            {
                Titulo = "Profesores"
                ,
                PaginaHija = typeof(ProfesoresView)
            };
            var administradoresview = new MasterPageItem()
            {
                Titulo = "Administradores"
                ,
                PaginaHija = typeof(AdministradoresView)
            };
            var seccionesview = new MasterPageItem()
            {
                Titulo = "Secciones"
                ,
                PaginaHija = typeof(SeccionesView)
            };
            menu.Add(miperfilview);
            menu.Add(alumnosview);
            menu.Add(profesoresview);
            menu.Add(administradoresview);
            menu.Add(seccionesview);
            this.lsvmenu.ItemsSource = menu;
            Detail =
                new NavigationPage((Page)Activator.CreateInstance(typeof(PaginaPrincipal)));
            this.lsvmenu.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.PaginaHija;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}