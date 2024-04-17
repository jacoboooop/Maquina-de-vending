﻿using System;
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
                Console.WriteLine("\t||||||||||||||||||||||||||||||||||||||||||||||||||");
                Console.WriteLine("\t||                                              ||");
                Console.WriteLine("\t||      Bienvenido a la maquina de vending      ||");
                Console.WriteLine("\t||                                              ||");
                Console.WriteLine("\t||||||||||||||||||||||||||||||||||||||||||||||||||");
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
                    Console.Write("Opcion: ");
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

                            Console.Clear();
                            Console.WriteLine("Como desea pagar la compra");
                            int opcionPago = int.Parse(Console.ReadLine());
                            Console.WriteLine("1. Pagar en efectivo");
                            Console.WriteLine("2. Pago con tarjeta");
                            switch (opcionPago)
                            {
                                case 1:
                                    Console.Clear();
                                    double dinero = 0;
                                    Console.WriteLine("Introducir monedas");
                                    Console.WriteLine($"Dinero necesario: {pago}\n");
                                    do
                                    {
                                        Console.WriteLine($"Dinero actual: {dinero}\n");
                                        Console.WriteLine("1. 5 cent");
                                        Console.WriteLine("2. 10 cent");
                                        Console.WriteLine("3. 20 cent");
                                        Console.WriteLine("4. 50 cent");
                                        Console.WriteLine("5. 1 euro");
                                        Console.WriteLine("6. 2 euros");
                                        Console.Write("\nOpcion: ");
                                    } while (dinero >= pago);
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Introduzca los datos de la tajeta");
                                    Console.Write("Numero de tarjeta: ");
                                    string numTarjeta = Console.ReadLine();
                                    if (numTarjeta.Length < 16)
                                    {
                                        Console.WriteLine("El numero de tarjeta tiene que tener por lo menos 16 dijitos");
                                        break;
                                    }
                                    else
                                    {
                                        Console.Write("Fecha de caducidad: ");
                                        DateTime caducidad = DateTime.Parse(Console.ReadLine());
                                        if (caducidad < DateTime.Now)
                                        {
                                            Console.WriteLine("Tarjeta caducada");
                                            break;
                                        }
                                        else
                                        {

                                            Console.Write("Numero secreto: ");
                                            string numSecreto = Console.ReadLine();
                                            if (numSecreto.Length < 3)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Gracias por su compra");

                                                foreach (Productos p in listaCompra)
                                                {
                                                    Console.WriteLine($"Se ha dispensado {p.Nombre}");
                                                }

                                                Console.ReadKey();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("El numero secreto tiene que tener un minimo de 3 digitos");
                                                break;
                                            }

                                        }
                                    }
                                default:
                                    Console.WriteLine("Opcion no valida");
                                    break;
                            }
                            break;
                        case 2:
                            break;
                        case 3:
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
