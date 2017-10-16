using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosMVC.Models
{
    public class trabajosPendientes
    {
        public int ID { get; set; }
        public string Cliente { get; set; }
        public string Descripcion { get; set; }
        public DateTime Recibido { get; set; }
        public DateTime Entrega { get; set; }
        public int Adelanto { get; set; }
        public int Total { get; set; }
    }
}