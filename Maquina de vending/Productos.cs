using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_de_vending {

    internal class Productos {

        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public double Precio_unitario { get; set; }
        public string Descripcion { get; set; }

        public Productos () { }
        public Productos(string nombre, int unidades, double precio_unitario, string descripcion) {
            Nombre = nombre;
            Unidades = unidades;
            Precio_unitario = precio_unitario;
            Descripcion = descripcion;
        }

	}
}
