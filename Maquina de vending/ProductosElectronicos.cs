using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_de_vending
{
    internal class ProductosElectronicos : Productos
    {
        public string Material {  get; set; }
        public bool Pilas {  get; set; }
        
        public bool Precargado { get; set; }


        public ProductosElectronicos() { }


        public ProductosElectronicos(string nombre, int unidades, double precio, string descripcion, string material, bool pilas, bool precargado) : base(nombre, unidades, precio, descripcion)
        {
            Material = material;
            Pilas = pilas;
            Precargado = precargado;
        }


        public override string MostrarInformcion()
        {
            return base.MostrarInformcion() + $"\nMaterial: {Material} \nPilas: {Pilas}  \nPrecargados: {Precargado}";
        }


        public override void SolicitarDetalles()
        {
            base.SolicitarDetalles();
            Console.Write("Materiales:");
            Material  =  Console.ReadLine();
            int RespuestaPilas = 5;
            do
            {
                Console.WriteLine("Si lleva pilas, marque 1, de lo contrario marque 0");
                Console.Write("OPCION: ");
                RespuestaPilas = int.Parse(Console.ReadLine());
                if (RespuestaPilas == 1)
                {
                    Pilas = true;
                }
                else if (RespuestaPilas == 0)
                {
                    Pilas = false;
                }
                else
                {
                    Console.WriteLine("Elige entre 1 o 0");
                }


            } while (RespuestaPilas == 0 || RespuestaPilas == 1);
            int Respuestaprecargadas = 5;
            do
            {
                Console.WriteLine("Si esta  precargado, marque 1, de lo contrario marque 0");
                Console.Write("OPCION: ");
                Respuestaprecargadas = int.Parse(Console.ReadLine());
                if (Respuestaprecargadas == 1)
                {
                    Precargado = true;
                }
                else if (RespuestaPilas == 0)
                {
                    Precargado = false;
                }
                else
                {
                    Console.WriteLine("Elige entre 1 o 0");
                }
            } while (Respuestaprecargadas == 0 || Respuestaprecargadas == 1);

        }
    }
}
