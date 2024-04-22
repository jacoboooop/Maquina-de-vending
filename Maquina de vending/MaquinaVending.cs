﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_de_vending {
    internal class MaquinaVending {

        public List<Productos> Productos { get; set; }

        public MaquinaVending(List<Productos> productos) {
            Productos = productos;
        }


        public static void MostrarInformacionProductos(List<Productos> listaProductos) {
            Console.Clear();
            Console.WriteLine("Estos son los productos disponibles: ");
            foreach (Productos p in listaProductos) {
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

        public void AñadirExistenciasDePreductos() {

            string nombre;

            Console.Clear();
            try {
                if (Productos.Count >= 12) {
                    Console.WriteLine("La lista de producos esta completa, no puede añadir más productos");
                }
                else {
                    Console.WriteLine($"Puede añadir como máximo {12 - Productos.Count} productos");
                    foreach (Productos item in Productos) {
                        Console.WriteLine($"{item.Nombre}");
                    }
                    Console.Write("Que tipo de producto quiere añadir: ");
                    nombre = Console.ReadLine();
                    bool verificar = Admin.VerificarProductoExistetnte(nombre);
                    if (verificar == true) {
                        foreach (Productos item in Productos) {
                            if (nombre == item.Nombre) {
                                Console.WriteLine("Cuantas unidades quieres añadir: ");
                                item.Unidades = int.Parse(Console.ReadLine());
                            }
                        }
                    }
                    else {
                        Console.WriteLine("Este producto no existe.");
                        Console.ReadKey();
                    }
                }
            }
            catch (FormatException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
