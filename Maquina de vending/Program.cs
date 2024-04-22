using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;

namespace Maquina_de_vending
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Productos> listaProductos = new List<Productos>();
            List<Productos> listaCompra = new List<Productos>();          

            Admin administrador = new Admin(listaProductos ,1234);  

            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\t|||||||||||||||||||||||||||||||||||||||||||||||||||");
                Console.WriteLine("\t||                                               ||");
                Console.WriteLine("\t||      Bienvenido a la maquina de vending       ||");
                Console.WriteLine("\t||                                               ||");
                Console.WriteLine("\t|||||||||||||||||||||||||||||||||||||||||||||||||||");
                Console.WriteLine("");
                Console.WriteLine("\t|||||||||||||||||||||||||||||||||||||||||||||||||||");
                Console.WriteLine("\t|                                                 |");
                Console.WriteLine("\t|  Escoga la opción que quiera:                   |");
                Console.WriteLine("\t|  1. Comprar productos                           |");
                Console.WriteLine("\t|  2. Mostrar información de productos            |");
                Console.WriteLine("\t|  3. Carga individual de productos               |");
                Console.WriteLine("\t|  4. Carga completa de productos                 |");
                Console.WriteLine("\t|  5. Salir                                       |");
                Console.WriteLine("\t|                                                 |");
                Console.WriteLine("\t|||||||||||||||||||||||||||||||||||||||||||||||||||");
                try
                {
                    Console.Write("\n\n\tOpcion: ");
                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            maquina.ComprarProducto();
                            break;
                        case 2:
                            maquina.MostrarInformacionProductos();
                            break;
                        case 3:

                            //Pedimos la contraseña del administrador

                            int contra = 0;
                            Console.Clear();
                            Console.Write("Esta opción es solo para administradores, introduzca la contraseña: ");
                            contra = int.Parse(Console.ReadLine());
                            bool comprobar = false;
                            comprobar = administrador.ComprobarContraseña(contra);
                            if (comprobar == true)
                            {
                                administrador.AñadirExistenciasDePreductos();
                            }
                            else
                            {
                                Console.WriteLine("La contraseña es incorrecta");
                                Console.ReadKey();  
                            }
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("La opción nos es valida");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
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
            else 
            { 
                Console.WriteLine("Gracias por la compra");
                
            }
        }
       

        public static void CargaIndividualDeProductos() {
            Console.Clear();
            Console.WriteLine("Que quiere hacer: ");
            Console.WriteLine();
        }

    }
}
