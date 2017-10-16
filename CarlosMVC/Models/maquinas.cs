using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosMVC.Models
{
    public class maquinas
    {
        public int ID { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Funcion { get; set; }
        public string Estado { get; set; }
    }
}