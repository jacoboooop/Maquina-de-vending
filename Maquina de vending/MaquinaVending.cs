using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
                Console.Clear();
                Console.WriteLine("1. Seguir comprando productos");
                Console.WriteLine("2. Pagar");
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
                            Console.Clear();
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
            Console.WriteLine("1. Pagar en efectivo");
            Console.WriteLine("2. Pago con tarjeta");
            Console.Write("\n\nOpcion: ");
            int opcionPago = int.Parse(Console.ReadLine());
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
            foreach (Productos p in listaProductos)
            {
                if (id == p.ID)
                {
                    if(p.Unidades == 0)
                    {
                        Console.WriteLine("El articulo no esta disponible");
                    }
                    else
                    {
                        verif = true;
                        listaCompra.Add(p);
                        p.Unidades--;
                    }
                }
            }
            if (verif == false)
            {
                Console.WriteLine("El ID no se ha encontrado");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Producto añadido a la compra");

                Console.ReadKey();
            }
        }

        public void AñadirPreductos(Admin admin)
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
                    int opcion = 0;
                    do {
                        Console.WriteLine("Que rieres hacer: ");
                        Console.WriteLine("     1. Añadir un producto existente");
                        Console.WriteLine("     2. Añadir un nuevo producto");
                        Console.WriteLine("     3. Salir");
                        try {
                            Console.Write(" Opción: ");
                            opcion = int.Parse(Console.ReadLine());
                            switch (opcion) {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine($"Puede añadir como máximo {12 - ListaProductos.Count} productos");
                                    foreach (Productos item in ListaProductos) {
                                        Console.WriteLine($"{item.Nombre}");
                                    }
                                    Console.Write("\nQue tipo de producto quiere añadir: ");
                                    nombre = Console.ReadLine();
                                    bool verificar = admin.VerificarProductoExistetnte(nombre);
                                    if (verificar == true) {
                                        foreach (Productos item in ListaProductos) {
                                            if (nombre == item.Nombre) {
                                                Console.Write("Cuantas unidades quieres añadir: ");
                                                int unidadesNuevas = int.Parse(Console.ReadLine());
                                                item.Unidades = item.Unidades + unidadesNuevas;
                                            }
                                        }
                                    }
                                    else {
                                        Console.WriteLine("Este producto no existe.");
                                        Console.ReadKey();
                                    }
                                    break;
                                case 2:
                                    int opcion2 = 0;
                                    Console.Clear();
                                    Console.WriteLine("Que tipo de producto quiere añadir: ");
                                    Console.WriteLine("     1. Material preciosos");
                                    Console.WriteLine("     2. Producto alimenticio");
                                    Console.WriteLine("     3. Producto electrónico");
                                    try {
                                        Console.Write(" Opción: ");
                                        opcion2 = int.Parse(Console.ReadLine());
                                        switch (opcion2) {
                                            case 1:
                                                Materiales_perciosos p = new Materiales_perciosos();
                                                p.SolicitarDetalles();
                                                p.TipoProducto = 1;
                                                ListaProductos.Add(p);
                                                break;
                                            case 2:
                                                ProductosAlimenticios a = new ProductosAlimenticios();
                                                a.SolicitarDetalles();
                                                a.TipoProducto = 2;
                                                ListaProductos.Add(a);
                                                break;
                                            case 3:
                                                ProductosElectronicos e = new ProductosElectronicos();
                                                e.SolicitarDetalles();
                                                e.TipoProducto = 3;
                                                ListaProductos.Add(e);
                                                break;
                                        }
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;
                                default: 
                                    Console.WriteLine("Opción no válida, por favor seleccione una opción correcta");
                                    break;
                            }
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                    } while (opcion != 3);
                    
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
            Console.Write("Que nombre tiene el archivo tipo txt para cargar los productos: ");
            string nombreArchivo = Console.ReadLine();

            if (File.Exists($"{nombreArchivo}.txt"))
            {

                using (StreamReader cargaProductos = File.OpenText($"{nombreArchivo}.txt"))
                {
                    while (!cargaProductos.EndOfStream)
                    {
                        string line = cargaProductos.ReadLine();
                        string[] values = line.Split(',');

                        if (values[0] == "1")
                        {
                            Materiales_perciosos m = new Materiales_perciosos(1, values[1], int.Parse(values[2]), double.Parse(values[3]), values[4], values[5], int.Parse(values[6]));
                            ListaProductos.Add(m);
                        }
                        else if (values[0] == "2")
                        {
                            ProductosAlimenticios p = new ProductosAlimenticios(2, values[1], int.Parse(values[2]), double.Parse(values[3]), values[4], double.Parse(values[5]), int.Parse(values[6]), double.Parse(values[7]));
                            ListaProductos.Add(p);
                        }
                        else if (values[0] == "3")
                        {
                            ProductosElectronicos e = new ProductosElectronicos(3, values[1], int.Parse(values[2]), double.Parse(values[3]), values[4], values[5], bool.Parse(values[6]), bool.Parse(values[7]));
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
