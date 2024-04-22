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

                            // Seleccionar productos

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

                            //Calcular el dinero que necesita para realizar la compra

                            double pago = 0;

                            foreach (Productos q in listaCompra)
                            {
                                pago = pago + q.Precio_unitario;
                            }

                            //Pagar la compra
                            
                            Pago pagar = new Pago(pago);

                            Console.Clear();
                            Console.WriteLine("Como desea pagar la compra");
                            int opcionPago = int.Parse(Console.ReadLine());
                            Console.WriteLine("1. Pagar en efectivo");
                            Console.WriteLine("2. Pago con tarjeta");
                            switch (opcionPago)
                            {
                                case 1:
                                    pagar.PagoEfectivo(listaCompra);
                                    break;
                                case 2:
                                    pagar.PagoTargeta(listaCompra);
                                    break;
                                default:
                                    Console.WriteLine("Opcion no valida");
                                    break;
                            }
                            break;
                        case 2:
                            break;
                        case 3:

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
                foreach (Productos e in listaProductos)
                {
                    if (e.Unidades == 0)
                    {
                        listaProductos.Remove(e);
                    }
                }
            }
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

        public static void CargaIndividualDeProductos() {
            Console.Clear();
            Console.WriteLine("Que quiere hacer: ");
            Console.WriteLine();
        }

    }
}
