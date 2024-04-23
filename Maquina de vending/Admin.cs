using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_de_vending
{
    internal class Admin
    {
        private int Contraseña {  get; set; }
        public List<Productos> Productos { get; set; }

        public Admin(List<Productos> productos, int contraseña)
        {
            Productos = productos;
            Contraseña = contraseña;
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
                    foreach(Productos item in Productos) {
                        Console.WriteLine($"{item.Nombre}");
                    }
                    Console.Write("Que tipo de producto desea añadir: ");
                    nombre = Console.ReadLine();
                    bool verificar = VerificarProductoExistetnte(nombre);
                    if (verificar == true) {
                        foreach(Productos item in Productos) { 
                            if(nombre == item.Nombre) {
                                Console.WriteLine("Cuantas unidades deseas añadir: ");
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
            catch(FormatException e) {
                Console.WriteLine(e.Message);  
            }
        }
        public void AñadirNuevosProductos() {
            if (File.Exists("cargaProductos.csv"){

                using (StreamReader cargaProductos = File.OpenText("cargaProductos.csv"))
                {
                    while (!cargaProductos.EndOfStream)
                    {
                        string line = cargaProductos.ReadLine();
                        string[] values = line.Split(';');

                        if (values.Length == 8)
                        {

                        }


                    }
                }

            }
        }

        public bool ComprobarContraseña(int contraseñaComprobacion)
        {
            if (contraseñaComprobacion == Contraseña)
            {
                return true;
            }
            return false;
        }

        public bool VerificarProductoExistetnte(string nombre) {
            foreach (Productos p in Productos) {
                if(nombre == p.Nombre) {
                    return true;
                }
            }
            return false;
        }



    }
}

