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
        public Materiales_perciosos(int tipoProducto, string nombre, int unidades, double precio_unitario, string descripcion, string tipo, int peso) : base(tipoProducto, nombre, unidades, precio_unitario, descripcion)
        {
            Tipo = tipo;
            Peso = peso;
        }

        public override string MostrarInformcion() {
            return base.MostrarInformcion() + $"\nTipo de producto {Tipo} \nPeso: {Peso}";
        }

        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            try {
                Console.Write("Tipo de producto: ");
                Tipo = Console.ReadLine();
                Console.Write("Peso: ");
                Peso = int.Parse(Console.ReadLine());
                Console.WriteLine("\nProducto añadido correctamente.");
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            
        }
    }
}