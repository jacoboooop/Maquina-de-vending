﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_de_vending {

    internal class Productos {

        public int ID { get; set; }
        public int TipoProducto { get; set; }
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public double Precio_unitario { get; set; }
        public string Descripcion { get; set; }

        static int contador = 1;

        public Productos() { }
        public Productos(int tipoProducto,string nombre, int unidades, double precio_unitario, string descripcion) {
            ID = contador;
            contador++;
            TipoProducto = tipoProducto;
            Nombre = nombre;
            Unidades = unidades;
            Precio_unitario = precio_unitario;
            Descripcion = descripcion;
        }
        public virtual string MostrarInformcion() {
            return $"ID: {ID} \nNombre: {Nombre} \nUnidades: {Unidades} \nPrecio: {Precio_unitario} \nDescripcion: {Descripcion} ";
        }

        public virtual void SolicitarDetalles() {
            Console.Clear();
            ID = contador;
            contador++;
            try {
                Console.Write("Nombre: ");
                Nombre = Console.ReadLine();
                Console.Write("Unidades: ");
                Unidades = int.Parse(Console.ReadLine());
                Console.Write("Precio: ");
                Precio_unitario = double.Parse(Console.ReadLine());
                Console.Write("Descripcion: ");
                Descripcion = Console.ReadLine();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            
        }

        public virtual string GuardadoMaquina()
        {
            return $"{ID},{Nombre},{Unidades},{Precio_unitario},{Descripcion}";
        }
    }
}

