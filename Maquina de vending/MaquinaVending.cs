﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_de_vending {
    internal class MaquinaVending {

        public List<Productos> ListaProductos { get; set; }

        public MaquinaVending(List<Productos> productos) {
            ListaProductos = productos;
        }


        public void MostrarInformacionProductos() {
            Console.Clear();
            Console.WriteLine("Estos son los productos disponibles: ");
            foreach (Productos p in ListaProductos) {
                Console.WriteLine($"{p.MostrarInformcion()}");
            }
            Console.Write("\n\nID: ");
            int id = int.Parse(Console.ReadLine());
            bool verif = false;
            foreach (Productos p in ListaProductos) {
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


        public void ComprarProducto()
        {
            List<Productos> listaCompra = new List<Productos>();

            // Seleccionar productos

            int opcionCompra = 0;
            ComprarProductos(ListaProductos, listaCompra);
            do
            {
                Console.WriteLine("1. Seguir comprando productos");
                Console.WriteLine("2. Pagar");
                opcionCompra = int.Parse(Console.ReadLine());
                try
                {
                    Console.Write("Opcion: ");
                    opcionCompra = int.Parse(Console.ReadLine());
                    switch (opcionCompra)
                    {
                        case 1:
                            ComprarProductos(ListaProductos, listaCompra);
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

        public void AñadirExistenciasDePreductos(Admin admin)
        {

            string nombre;

            Console.Clear();
            try
            {
                if (ListaProductos.Count >= 12)
                {
                    Console.WriteLine("La lista de producos esta completa, no puede añadir más productos");
                }
                else
                {
                    Console.WriteLine($"Puede añadir como máximo {12 - ListaProductos.Count} productos");
                    foreach (Productos item in ListaProductos)
                    {
                        Console.WriteLine($"{item.Nombre}");
                    }
                    Console.Write("Que tipo de producto quiere añadir: ");
                    nombre = Console.ReadLine();
                    bool verificar = admin.VerificarProductoExistetnte(nombre);
                    if (verificar == true)
                    {
                        foreach (Productos item in ListaProductos)
                        {
                            if (nombre == item.Nombre)
                            {
                                Console.WriteLine("Cuantas unidades quieres añadir: ");
                                item.Unidades = int.Parse(Console.ReadLine());
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Este producto no existe.");
                        Console.ReadKey();
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AñadirNuevosProductos()
        {
            Console.Clear();
            Console.Write("Que nombre tiene el archvio tipo csv para cargar los productos: ");
            string nombreArchivo = Console.ReadLine();

            if (File.Exists($"{nombreArchivo}.csv"))
            {

                using (StreamReader cargaProductos = File.OpenText($"{nombreArchivo}.csv"))
                {
                    while (!cargaProductos.EndOfStream)
                    {
                        string line = cargaProductos.ReadLine();
                        string[] values = line.Split(';');

                        if (values[1] == "1")
                        {
                            Materiales_perciosos m = new Materiales_perciosos(int.Parse(values[1]), values[2], int.Parse(values[3]), double.Parse(values[4]), values[5], values[6], int.Parse(values[7]));
                            ListaProductos.Add(m);
                        }
                        else if (values[1] == "2")
                        {
                            ProductosAlimenticios p = new ProductosAlimenticios(int.Parse(values[1]), values[2], int.Parse(values[3]), double.Parse(values[4]), values[5], double.Parse(values[6]), int.Parse(values[7]), double.Parse(values[8]));
                            ListaProductos.Add(p);
                        }
                        else if (values[1] == "3")
                        {
                            ProductosElectronicos e = new ProductosElectronicos(int.Parse(values[1]), values[2], int.Parse(values[3]), double.Parse(values[4]), values[5], values[6], bool.Parse(values[7]), bool.Parse(values[8]));
                            ListaProductos.Add(e);
                        }

                    }
                }

            }
            else
            {
                Console.WriteLine("Archivo no encontrado");
                Console.ReadKey();
            }
        }
    }
}
