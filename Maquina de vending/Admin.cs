using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_de_vending
{
    internal class Admin : Usuario
    {
        public int Contraseña {  get; set; }

        public Admin(List<Productos> Productos) : base(Productos) { }
        public Admin(int contraseña) {
            Contraseña = contraseña;      
        }
        
        public void AñadirExistenciasDePreductos() {

            string nombre;

            Console.Clear();
            try {
                if (listaProductos.Count >= 11) {
                    Console.WriteLine("La lista de producos esta completa, no puede añadir más productos");
                }
                else {
                    Console.WriteLine($"Puede añadir como máximo {12 - listaProductos.Count} productos");
                }
                Console.Write("Que tipo de producto quiere añadir: ");
                nombre = Console.ReadLine();
                foreach (Productos p in listaProductos) {
                    if (nombre == p.Nombre) {
                        p.Nombre = nombre;
                        Console.Write("Cuantas unidades quiere añadir: ");
                        p.Unidades = int.Parse(Console.ReadLine());
                        Console.Write("Precio por unidad del producto: ");
                        p.Precio_unitario = int.Parse(Console.ReadLine());
                        listaProductos.Add(p);
                    }
                    else {
                        Console.WriteLine("El producto no existe");
                        Console.ReadKey();
                    }
                }
            }
            catch(FormatException e) {
                Console.WriteLine(e.Message);  
            }
        }
        public void AñadirNuevosProductos() {
            
        }
    }
}

