using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_de_vending
{
    internal class ProductosAlimenticios : Productos
    {
        public double Calorias { get; set; }
        public double  Grasas { get; set; }
        public double Azucares { get; set; }



        public ProductosAlimenticios() { }



        public ProductosAlimenticios(int tipoProducto, string nombre, int unidades, double precio_unitario, string descripcion, double calorias, double grasas, double azucares)  : base(tipoProducto,nombre, unidades, precio_unitario, descripcion)
        {
            Calorias = calorias;
            Grasas = grasas;
            Azucares = azucares;
            
        }


        public override string MostrarInformcion()
        {
            return base.MostrarInformcion() + $"\nCalorias: {Calorias} \nGrasas: {Grasas} \nAzucares: {Azucares}";
        }

        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            try {
                Console.Write("Calorias: ");
                Calorias = int.Parse(Console.ReadLine());
                Console.Write("Grasas: ");
                Grasas = int.Parse(Console.ReadLine());
                Console.Write("Azúcares: ");
                Azucares = int.Parse(Console.ReadLine());
                Console.WriteLine("\nProducto añadido correctamente.");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
