using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosMVC.Models
{
    public class inventario
    {
        public int ID { get; set; }
        public int Cantidad { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public int Costo { get; set; }
    }
}