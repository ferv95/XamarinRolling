using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinRolling.Models
{
    public class Secciones
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("Seccion")]
        public int Seccion { get; set; }
        [JsonProperty("Situacion")]
        public String Situacion { get; set; }
        [JsonProperty("DIRECCION")]
        public String Direccion { get; set; }
        [JsonProperty("EMAIL")]
        public String Email { get; set; }
        [JsonProperty("TELEFONO")]
        public int Telefono { get; set; }

    }
}
