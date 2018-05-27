using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinRolling.Models
{
    public class Plantilla
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("NOMBRE")]
        public String Nombre { get; set; }
        [JsonProperty("APELLIDO")]
        public String Apellido { get; set; }
        [JsonProperty("Horario")]
        public String Horario { get; set; }
        [JsonProperty("TELEFONO")]
        public int Telefono { get; set; }
        [JsonProperty("SECCION")]
        public int Seccion { get; set; }
        [JsonProperty("Practicas")]
        public String Practicas { get; set; }
        [JsonProperty("Teoricas")]
        public String Teoricas { get; set; }
        [JsonProperty("CODIGO")]
        public int Codigo { get; set; }
        [JsonProperty("Password")]
        public String Password { get; set; }
        [JsonProperty("Rol")]
        public String Rol { get; set; }
        [JsonProperty("Email")]
        public String Email { get; set; }
        [JsonProperty("USUARIO")]
        public String Usuario { get; set; }
        [JsonProperty("IMAGE")]
        public String Image { get; set; }

        public String NombreApellido
        {
            get
            {
                return this.Nombre + " " + this.Apellido;
            }
        }
    }
}
