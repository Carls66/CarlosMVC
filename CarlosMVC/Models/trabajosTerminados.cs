using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosMVC.Models
{
    public class trabajosTerminados
    {
        public int ID { get; set; }
        public string Cliente { get; set; }
        public string Descripcion { get; set; }
        public DateTime Recibido { get; set; }
        public DateTime Entregado { get; set; }
        public decimal Total { get; set; }
    }
}