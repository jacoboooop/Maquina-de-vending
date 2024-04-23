using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
        
        public void AñadirNuevosProductos() 
        {
            Console.Clear();
            Console.Write("Que nombre tiene el archvio tipo csv para cargar los productos: ");
            string nombreArchivo = Console.ReadLine();

            if (File.Exists($"{nombreArchivo}.csv")) {

                using (StreamReader cargaProductos = File.OpenText($"{nombreArchivo}.csv"))
                {
                    int contador = 1;
                    while (!cargaProductos.EndOfStream)
                    {
                        string line = cargaProductos.ReadLine();
                        string[] values = line.Split(';');
                        
                        if (values[1] == "1")
                        {
                            Materiales_perciosos m = new Materiales_perciosos(values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
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

