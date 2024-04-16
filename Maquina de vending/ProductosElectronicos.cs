using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_de_vending
{
    internal class ProductosElectronicos : Productos
    {
        public string Materiales {  get; set; }
        public bool Pilas {  get; set; }
        
        public bool Precargado { get; set; }


        public ProductosElectronicos() { }


        public ProductosElectronicos(string materiales) { }
    }
}
