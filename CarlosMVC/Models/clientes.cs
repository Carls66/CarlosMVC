using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosMVC.Models
{
    public class clientes
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public decimal Edad { get; set; }
        public string Credito { get; set; }
    }
}