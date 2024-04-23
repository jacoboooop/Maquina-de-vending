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

