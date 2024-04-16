using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Maquina_de_vending
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Productos> listaProductos = new List<Productos>();
            List<Productos> listaCompra = new List<Productos>();

            int opcion = 0;
            do
            {
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
                try
                {
                    Console.Write("Opcion: ");
                    opcion = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                switch (opcion)
                {
                    case 1:
                        int opcionCompra = 0;
                        ComprarProductos(listaProductos, listaCompra);
                        do
                        {
                            Console.WriteLine("1. Seguir comprando productos");
                            Console.WriteLine("2. Pagar");
                            opcionCompra = int.Parse(Console.ReadLine());
                            try
                            {
                                Console.Write("Opcion: ");
                                opcion = int.Parse(Console.ReadLine());
                                switch (opcionCompra)
                                {
                                    case 1:
                                        ComprarProductos(listaProductos, listaCompra);
                                        break;
                                    case 2:
                                        Console.WriteLine("Vamos a pagar la compra...");
                                        break;

                                }
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.ReadKey();
                            }

                        } while (opcionCompra != 2);

                        Console.WriteLine("Como desea pagar la compra");
                        int opcionPago = int.Parse(Console.ReadLine());
                        Console.WriteLine("1. Pagar en efectivo");
                        Console.WriteLine("2. Pago con tarjeta");
                        switch (opcionPago)
                        {
                            case 1:
                                Console.WriteLine("Introducir monedas");
                                do
                                {

                                } while ();
                                break;
                            case 2:
                                break;
                            default:
                                Console.WriteLine("Opcion no valida");
                                break;
                        }
                         

                        break;
                    default:
                        Console.WriteLine("La opción nos es valida");
                        break;
                }
            } while (opcion != 5);
        }

        public static void ComprarProductos(List<Productos> listaProductos, List<Productos> listaCompra)
        {
            Console.Clear();
            Console.WriteLine("Introduzca el ID del producto que sea comprar\n\n");
            foreach (Productos p in listaProductos)
            {
                Console.WriteLine($"{p.MostrarInformcion()}");
            }
            Console.Write("\n\nID: ");
            int id = int.Parse(Console.ReadLine());
            bool verif = false;
            foreach (Productos p in listaCompra)
            {
                if (id == p.ID)
                {
                    verif = true;
                    listaCompra.Add(p);
                }
            }
            if (verif == false)
            {
                Console.WriteLine("El ID no se ha encontrado");
            }
            else { Console.WriteLine("Gracias por la compra"); }
        }

        public static void MostrarInformacionProductos(List<Productos> listaProductos)
        {
            Console.Clear();
            Console.WriteLine("Estos son los productos disponibles: ");
            foreach (Productos p in listaProductos)
            {
                Console.WriteLine($"{p.MostrarInformcion()}");
            }
            Console.Write("\n\nID: ");
            int id = int.Parse(Console.ReadLine());
            bool verif = false;
            foreach (Productos p in listaProductos)
            {
                if (id == p.ID)
                {
                    verif = true;
                    Console.WriteLine($"{p.MostrarInformcion()}");
                    Console.ReadKey();
                }
            }
            if (verif == false)
            {
                Console.WriteLine("El id no coincide con ningún producto");
            }
        }
    }
}
