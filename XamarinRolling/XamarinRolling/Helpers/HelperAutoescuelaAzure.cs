using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinRolling.Models;

namespace XamarinRolling.Helpers
{
    public class HelperAutoescuelaAzure
    {
        private const string DireccionApi = "http://apiautoescuelailr.azurewebsites.net/";

        private HttpClient CrearCliente()
        {
            HttpClient clientehttp = new HttpClient();
            clientehttp.DefaultRequestHeaders.Accept.Clear();
            clientehttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return clientehttp;
        }

        public async Task<List<Alumno>> GetAlumnos()
        {
            List<Alumno> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/GetAlumnos";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Alumno>>(contenido);
                //Comprobacion de imagen
                foreach (Alumno a in listadatos)
                {
                    if (a.Image == null)
                    {
                        a.Image = "avatar.png";
                    }
                }
            }
            return listadatos;
        }

        public async Task<List<Plantilla>> GetProfesores()
        {
            List<Plantilla> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/GetProfesores";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Plantilla>>(contenido);
                //Comprobacion de imagen
                foreach (Plantilla a in listadatos)
                {
                    if (a.Image == null)
                    {
                        a.Image = "avatar.png";
                    }
                }
            }
            return listadatos;
        }

        public async Task<List<Plantilla>> GetAdministradores()
        {
            List<Plantilla> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/GetAdministradores";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Plantilla>>(contenido);
                //Comprobacion de imagen
                foreach (Plantilla a in listadatos)
                {
                    if (a.Image == null)
                    {
                        a.Image = "avatar.png";
                    }
                }
            }
            return listadatos;
        }

        public async Task<List<Secciones>> GetOficinas()
        {
            List<Secciones> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/GetOficinas";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Secciones>>(contenido);
            }
            return listadatos;
        }

        public async Task<List<int>> GetDistSecciones()
        {
            List<int> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/GetDistSecciones";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<int>>(contenido);
            }
            return listadatos;
        }

        public async Task<List<String>> GetDistEmpRoles()
        {
            List<String> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/GetDistEmpRoles";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<String>>(contenido);
            }
            return listadatos;
        }

        public async Task<Alumno> ExisteAlumno(String usuario, String password)
        {
            Alumno alumno = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/ExisteAlumno?usuario=" + usuario + "&password=" + password;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                alumno = JsonConvert.DeserializeObject<Alumno>(contenido);
            }
            return alumno;
        }

        public async Task<Plantilla> ExisteEmpleado(String usuario, String password)
        {
            Plantilla emp = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/ExisteEmpleado?usuario=" + usuario + "&password=" + password;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<Plantilla>(contenido);
            }
            return emp;
        }

        public async Task<Alumno> ExisteAlumnoMail(String usuario, String email)
        {
            Alumno alumno = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/ExisteAlumnoMail?usuario=" + usuario + "&email=" + email;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                alumno = JsonConvert.DeserializeObject<Alumno>(contenido);
            }
            return alumno;
        }

        public async Task<Plantilla> ExisteEmpleadoMail(String usuario, String email)
        {
            Plantilla emp = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/ExisteEmpleadoMail?email=" + email;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<Plantilla>(contenido);
            }
            return emp;
        }

        public async Task<Plantilla> GetEmpleado(int id)
        {
            Plantilla emp = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/GetEmpleado?id=" + id;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<Plantilla>(contenido);
            }
            return emp;
        }

        public async Task<Plantilla> GetProfesor(int id)
        {
            Plantilla emp = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/GetProfesor?id=" + id;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<Plantilla>(contenido);
            }
            return emp;
        }

        public async Task<Plantilla> GetAdministrador(int id)
        {
            Plantilla emp = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/GetAdministrador?id=" + id;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<Plantilla>(contenido);
            }
            return emp;
        }

        public async Task<Alumno> GetAlumno(int id)
        {
            Alumno alumno = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/GetAlumno?id=" + id;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                alumno = JsonConvert.DeserializeObject<Alumno>(contenido);
            }
            return alumno;
        }

        public async Task<Secciones> ExisteSeccion(int id)
        {
            Secciones ofi = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/ExisteSeccion?id=" + id;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                ofi = JsonConvert.DeserializeObject<Secciones>(contenido);
            }
            return ofi;
        }

        public async Task<Secciones> GetSeccion(int id)
        {
            Secciones ofi = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/GetSeccion?id=" + id;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                ofi = JsonConvert.DeserializeObject<Secciones>(contenido);
            }
            return ofi;
        }

        public async Task<Alumno> ExisteAlumnoUsuario(String usuario)
        {
            Alumno alumno = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/ExisteAlumnoUsuario?usuario=" + usuario;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                alumno = JsonConvert.DeserializeObject<Alumno>(contenido);
            }
            return alumno;
        }

        public async Task<Plantilla> ExisteEmpleadoUsuario(String usuario)
        {
            Plantilla emp = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/ExisteEmpleadoUsuario?usuario=" + usuario;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<Plantilla>(contenido);
            }
            return emp;
        }

        public async Task<Secciones> ExisteSeccionNombre(String nombre)
        {
            Secciones ofi = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/ExisteSeccionNombre?nombre=" + nombre;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                ofi = JsonConvert.DeserializeObject<Secciones>(contenido);
            }
            return ofi;
        }

        public async Task<Alumno> BuscarAlumnosNombre(String nombre)
        {
            Alumno alumno = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/BuscarAlumnosNombre/" + nombre;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                alumno = JsonConvert.DeserializeObject<Alumno>(contenido);
            }
            return alumno;
        }

        public async Task<Alumno> BuscarAlumnosApellidos(String Apellidos)
        {
            Alumno alumno = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/BuscarAlumnosApellidos/" + Apellidos;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                alumno = JsonConvert.DeserializeObject<Alumno>(contenido);
            }
            return alumno;
        }

        public async Task<Plantilla> BuscarProfesorNombre(String nombre)
        {
            Plantilla emp = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/BuscarProfesorNombre/" + nombre;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<Plantilla>(contenido);
            }
            return emp;
        }

        public async Task<Plantilla> BuscarProfesorApellidos(String Apellidos)
        {
            Plantilla emp = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/BuscarProfesorApellidos/" + Apellidos;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<Plantilla>(contenido);
            }
            return emp;
        }

        public async Task<Plantilla> BuscarAdministradorNombre(String nombre)
        {
            Plantilla emp = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/BuscarAdministradorNombre/" + nombre;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<Plantilla>(contenido);
            }
            return emp;
        }

        public async Task<Plantilla> BuscarAdministradorApellidos(String Apellidos)
        {
            Plantilla emp = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/BuscarAdministradorApellidos/" + Apellidos;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<Plantilla>(contenido);
            }
            return emp;
        }

        public async Task<bool> ModificarEmpleado(Plantilla empleado)
        {
            string jsondoctor = JsonConvert.SerializeObject(empleado, Formatting.Indented);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsondoctor);
            ByteArrayContent content = new ByteArrayContent(buffer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient client = CrearCliente();
            String peticion = DireccionApi + "api/ModificarEmpleado/" + empleado.Codigo;
            var respuesta = await client.PutAsync(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EditarAlumnoPass(Alumno alumno)
        {
            string jsondoctor = JsonConvert.SerializeObject(alumno, Formatting.Indented);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsondoctor);
            ByteArrayContent content = new ByteArrayContent(buffer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient client = CrearCliente();
            String peticion = DireccionApi + "api/EditarAlumnoPass";
            var respuesta = await client.PutAsync(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ModificarAlumno(Alumno alumno)
        {
            String nombre = alumno.Nombre;
            string jsondoctor = JsonConvert.SerializeObject(alumno, Formatting.Indented);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsondoctor);
            ByteArrayContent content = new ByteArrayContent(buffer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient client = CrearCliente();
            String peticion = DireccionApi + "api/ModificarAlumno/" + alumno.Codigo;
            var respuesta = await client.PutAsync(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ModificarSeccion(Secciones seccion)
        {
            string jsondoctor = JsonConvert.SerializeObject(seccion, Formatting.Indented);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsondoctor);
            ByteArrayContent content = new ByteArrayContent(buffer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient client = CrearCliente();
            String peticion = DireccionApi + "api/ModificarAlumno/" + seccion.Seccion;
            var respuesta = await client.PutAsync(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CrearAlumno(Alumno alumno)
        {
            string jsondoctor = JsonConvert.SerializeObject(alumno, Formatting.Indented);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsondoctor);
            ByteArrayContent content = new ByteArrayContent(buffer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient client = CrearCliente();
            String peticion = DireccionApi + "api/CrearAlumno";
            var respuesta = await client.PostAsync(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CrearSeccion(Secciones oficina)
        {
            string jsondoctor = JsonConvert.SerializeObject(oficina, Formatting.Indented);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsondoctor);
            ByteArrayContent content = new ByteArrayContent(buffer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient client = CrearCliente();
            String peticion = DireccionApi + "api/CrearSeccion";
            var respuesta = await client.PostAsync(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CrearProfesor(Plantilla emp)
        {
            string jsondoctor = JsonConvert.SerializeObject(emp, Formatting.Indented);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsondoctor);
            ByteArrayContent content = new ByteArrayContent(buffer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient client = CrearCliente();
            String peticion = DireccionApi + "api/CrearProfesor";
            var respuesta = await client.PostAsync(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EliminarAlumno(int codigo)
        {
            //CREAMOS EL CLIENTE
            HttpClient client = CrearCliente();
            //CREAMOS LA PETICION PUT
            String peticion = DireccionApi + "api/EliminarAlumno?codigo=" + codigo;
            //REALIZAMOS LA LLAMADA AL API
            var respuesta = await client.DeleteAsync(peticion);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EliminarProfesor(int codigo)
        {
            //CREAMOS EL CLIENTE
            HttpClient client = CrearCliente();
            //CREAMOS LA PETICION PUT
            String peticion = DireccionApi + "api/EliminarProfesor?codigo=" + codigo;
            //REALIZAMOS LA LLAMADA AL API
            var respuesta = await client.DeleteAsync(peticion);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EliminarOficina(int seccion)
        {
            //CREAMOS EL CLIENTE
            HttpClient client = CrearCliente();
            //CREAMOS LA PETICION PUT
            String peticion = DireccionApi + "api/EliminarOficina?codigo=" + seccion;
            //REALIZAMOS LA LLAMADA AL API
            var respuesta = await client.DeleteAsync(peticion);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EliminarAdministrador(int codigo)
        {
            //CREAMOS EL CLIENTE
            HttpClient client = CrearCliente();
            //CREAMOS LA PETICION PUT
            String peticion = DireccionApi + "api/EliminarAdministrador?codigo=" + codigo;
            //REALIZAMOS LA LLAMADA AL API
            var respuesta = await client.DeleteAsync(peticion);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
