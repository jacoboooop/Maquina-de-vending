using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Maquina_de_vending {
    internal class Program {
        static void Main(string[] args) {

            List<Productos> listaProductos = new List<Productos>();
             
            int opcion = 0;
            do {
                Console.Clear();
                Console.WriteLine("-----Binevenido a la máquina de vending-----");
                Console.WriteLine("");
                Console.WriteLine("Escoga la opción que quiera: ");
                Console.WriteLine("     1. Comprar productos");
                Console.WriteLine("     2, Mostrar información de productos");
                Console.WriteLine("     3. Carga individual de productos");
                Console.WriteLine("     4. Carga completa de productos");
                Console.WriteLine("     5. Salir");
                Console.WriteLine("");
                try {
                    Console.Write("Opcion: ");
                    opcion = int.Parse(Console.ReadLine());
                }
                catch(FormatException e) {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                switch (opcion)
                {
                    case 1:

                        break;
                    default:
                        Console.WriteLine("La opción nos es valida");
                        break;
                }
            } while (opcion != 5);
        }

        public static void ComprarProductos()
        {
            Console.Clear();
            Console.WriteLine("Introduzca el ID del producto que sea comprar\n\n");
            foreach (Productos p in listaProductos)
            {
                Console.WriteLine($"{p.MostrarInformcion()}");
            }
            Console.Write("\n\nID: ");
        }

        public static void MostrarInformacionProductos(List<Productos> listaProductos) {
            Console.Clear();
            Console.WriteLine("Estos son los productos disponibles: ");
            foreach(Productos p in listaProductos) {
                Console.WriteLine($"{p.MostrarInformcion()}");
            }
            Console.Write("\n\nID: ");
            int id = int.Parse(Console.ReadLine());
            bool verif = false;
            foreach (Productos p in listaProductos) {
                if (id == p.ID) {
                    verif = true;
                    Console.WriteLine($"{p.MostrarInformcion()}");
                    Console.ReadKey();
                }
            }
            if (verif == false) {
                Console.WriteLine("El id no coincide con ningún producto");
            }
        }
    }
}
