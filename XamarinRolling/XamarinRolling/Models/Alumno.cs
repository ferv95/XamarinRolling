using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinRolling.Models
{
    public class Alumno
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("NOMBRE")]
        public String Nombre { get; set; }
        [JsonProperty("APELLIDOS")]
        public String Apellidos { get; set; }
        [JsonProperty("DIRECCION")]
        public String Direccion { get; set; }
        [JsonProperty("TELEFONO")]
        public int Telefono { get; set; }
        [JsonProperty("SECCION")]
        public int Seccion { get; set; }
        [JsonProperty("FECHA_DE_NACIMIENTO")]
        public String FechaNacimiento { get; set; }
        [JsonProperty("CODIGO")]
        public int Codigo { get; set; }
        [JsonProperty("PASSWORD")]
        public String Password { get; set; }
        [JsonProperty("ROL")]
        public String Rol { get; set; }
        [JsonProperty("EMAIL")]
        public String Email { get; set; }
        [JsonProperty("USUARIO")]
        public String Usuario { get; set; }
        [JsonProperty("IMAGE")]
        public String Image { get; set; }

    }
}
