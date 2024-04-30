using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;
using System.IO;


namespace Maquina_de_vending
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Productos> listaProductos = new List<Productos>();
            MaquinaVending maquina = new MaquinaVending(listaProductos);

            Admin administrador = new Admin(listaProductos, 1234);

            if (File.Exists("guardado.txt"))
            {
                StreamReader guardado = File.OpenText("guardado.txt");

                string line = guardado.ReadLine();
                string[] values = line.Split(',');

                if (values[0] == "1")
                {
                    Materiales_perciosos m = new Materiales_perciosos(1, values[1], int.Parse(values[2]), double.Parse(values[3]), values[4], values[5], int.Parse(values[6]));
                    listaProductos.Add(m);
                }
                else if (values[0] == "2")
                {
                    ProductosAlimenticios p = new ProductosAlimenticios(2, values[1], int.Parse(values[2]), double.Parse(values[3]), values[4], double.Parse(values[5]), int.Parse(values[6]), double.Parse(values[7]));
                    listaProductos.Add(p);
                }
                else if (values[0] == "3")
                {
                    ProductosElectronicos e = new ProductosElectronicos(3, values[1], int.Parse(values[2]), double.Parse(values[3]), values[4], values[5], bool.Parse(values[6]), bool.Parse(values[7]));
                    listaProductos.Add(e);
                }

            }

     
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
                Console.WriteLine("\t||||||||||||||||||||||||||||||||||||||||||||||||||||");
                Console.WriteLine("\t||                                                ||");
                Console.WriteLine("\t||     Escoga la opción que quiera:               ||");
                Console.WriteLine("\t||     1. Comprar productos                       ||");
                Console.WriteLine("\t||     2. Mostrar información de productos        ||");
                Console.WriteLine("\t||     3. Carga individual de productos           ||");
                Console.WriteLine("\t||     4. Carga completa de productos             ||");
                Console.WriteLine("\t||     5. Salir                                   ||");
                Console.WriteLine("\t||                                                ||");
                Console.WriteLine("\t||||||||||||||||||||||||||||||||||||||||||||||||||||");
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
                            if (Login(administrador) == true){
                                maquina.AñadirPreductos(administrador);
                            }
                            break;
                        case 4:
                            if (Login(administrador) == true) {
                                maquina.AñadirNuevosProductos();
                            }
                            break;
                        case 5:
                            Console.WriteLine("Hasta la proxima");
                            Guardado(listaProductos);
                            Console.ReadKey();
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
            Console.WriteLine("Introduzca el ID del producto que desea comprar\n\n");
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
                Console.WriteLine("Gracias por su compra");
                
            }
        }
       
        public static bool Login(Admin administrador) {
            int contra = 0;
            
            Console.Clear();
            Console.Write("Esta opción es solo para administradores, introduzca la contraseña: ");
            contra = int.Parse(Console.ReadLine());
            bool comprobar = false;
            comprobar = administrador.ComprobarContraseña(contra);
            if(comprobar == true){
                return true;
            }
            else {
                return false;
            }
        }

        public static void Guardado(List<Productos> listaProductos)
        {
            String path = "guardado.txt";

            StreamWriter sr = new StreamWriter(path);

            foreach (Productos p in listaProductos)
            {
                sr.WriteLine(p.GuardadoMaquina());
            }

            sr.Close();

        }
    }
}
