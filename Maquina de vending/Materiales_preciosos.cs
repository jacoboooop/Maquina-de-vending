using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_de_vending {
    internal class Materiales_perciosos : Productos{

        public string Tipo {  get; set; }
        public int Peso { get; set; }

        public Materiales_perciosos() { }
        public Materiales_perciosos(string nombre, int unidades, double precio_unitario, string descripcion, string tipo, int peso)
            : base(nombre, unidades, precio_unitario, descripcion) {
            Tipo = tipo;
            Peso = peso;
        }
    }
}