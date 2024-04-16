using System;
using System.Collections.Generic;
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



        public ProductosAlimenticios(double calorias, double grasas, double azucares)
        {
            Calorias = calorias;
            Grasas = grasas;
            Azucares = azucares;
            
        }


        public override string MostrarInformcion()
        {
            return base.MostrarInformcion() + $"\nCalorias: {Calorias} \nGrasas: {Grasas} \nAzucares: {Azucares}";
        }
    }
}
