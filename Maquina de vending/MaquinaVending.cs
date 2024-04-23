using System;
using System.Collections.Generic;
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
    }
}
