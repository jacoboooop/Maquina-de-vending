using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_de_vending
{
    internal class Pago
    {
        //Atributos
        public double DineroNecesario { get; set; }

        //Constructor

        public Pago (double dineroNecesario)
        {
            DineroNecesario = dineroNecesario;
        }

        //Metodos

        public void PagoEfectivo(List<Productos> listaCompra)
        {
            Console.Clear();
            double dinero = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Introducir monedas");
                Console.WriteLine($"Dinero necesario: {DineroNecesario}\n");
                Console.WriteLine($"Dinero actual: {dinero}\n");
                Console.WriteLine("1. 5 cent");
                Console.WriteLine("2. 10 cent");
                Console.WriteLine("3. 20 cent");
                Console.WriteLine("4. 50 cent");
                Console.WriteLine("5. 1 euro");
                Console.WriteLine("6. 2 euros");
                Console.Write("\n\nOpcion: ");
                int opcionDinero = int.Parse(Console.ReadLine());
                switch (opcionDinero)
                {
                    case 1:
                        dinero = dinero + 0.05;
                        break;
                    case 2:
                        dinero = dinero + 0.10;
                        break;
                    case 3:
                        dinero = dinero + 0.20;
                        break;
                    case 4:
                        dinero = dinero + 0.50;
                        break;
                    case 5:
                        dinero = dinero + 1;
                        break;
                    case 6:
                        dinero = dinero + 2;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.Write("\nOpcion: ");
            } while (dinero <= DineroNecesario);

            //Controlar que se ha pagado mas de lo necesario

            if(dinero > DineroNecesario)
            {
                double vuelta = dinero - DineroNecesario;
                Console.WriteLine($"Se le ha deuelto {vuelta}");
            }

            Console.WriteLine("Gracias por su compra");

            foreach (Productos p in listaCompra)
            {
                Console.WriteLine($"Se ha dispensado {p.Nombre}");
            }

            Console.ReadKey();
        }

        public void PagoTargeta(List<Productos> listaCompra)
        {
            Console.Clear();
            Console.WriteLine("Introduzca los datos de la tajeta");
            Console.Write("Numero de tarjeta: ");
            string numTarjeta = Console.ReadLine();
            do
            {
                if (numTarjeta.Length < 16)
                {
                    Console.WriteLine("El numero de tarjeta tiene que tener por lo menos 16 dijitos");
                    Console.ReadKey();
                    return;
                }

                else
                {
                    Console.Write("Fecha de caducidad: ");
                    DateTime caducidad = DateTime.Parse(Console.ReadLine());
                    if (caducidad < DateTime.Now)
                    {
                        Console.WriteLine("Tarjeta caducada");
                        return;
                    }
                    else
                    {

                        Console.Write("Numero secreto: ");
                        string numSecreto = Console.ReadLine();
                        if (numSecreto.Length < 4)
                        {

                            Console.WriteLine("El numero secreto tiene que tener un minimo de 3 digitos");
                            return;

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Gracias por su compra");

                            foreach (Productos p in listaCompra)
                            {
                                Console.WriteLine($"Se ha dispensado {p.Nombre}");
                            }

                            Console.ReadKey();
                            return;
                        }

                    }
                }

            } while (numTarjeta.Length != 16);
            
        }
    }
}
