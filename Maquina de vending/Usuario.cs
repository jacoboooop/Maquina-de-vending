using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_de_vending
{
    internal class Usuario
    {

        //Atributos

        public double Dinero { get; private set; }
        protected List<Productos> listaProductos;

        //Constructor 

        public Usuario() { }

        public Usuario(double dinero, List<Productos> Productos)
        {
            Dinero = dinero;
            listaProductos = Productos;
        }

        public Usuario(List<Productos> productos) {
        }

        //Metodos
        public string MostrarDinero()
        {
            return $"Dinero disponible: {Dinero}";
        }

        public  void AñadirDinero(double añadido)
        {
            Dinero += añadido;
            Console.WriteLine($"Cuenta con {Dinero} euros para consumir");
        }

        public void RetirarDinero()
        {
            Dinero = 0;
            Console.WriteLine("Su dinero ha sido retirado");
            Console.WriteLine($"Cuenta con {Dinero} euros para consumir");
        }

        public void ComprarArticulo(double precio)
        {
            double resto = Dinero - precio;

            if (precio > Dinero)
            {
                Console.WriteLine("El precio del articulo supera al Dinero");
                if (resto < 1)
                {
                    Console.WriteLine($"Le faltan {resto} centimos");
                }
                else
                {
                    Console.WriteLine($"Le faltan {resto} euros");
                }
            }
            else
            {
                Console.WriteLine("Articulo comprado correctamente...");
                Console.WriteLine($"Su cambio es de {resto}");
            }
        }
    }
}
