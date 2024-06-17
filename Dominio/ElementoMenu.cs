using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ElementoMenu
    {
        public int IdMenu {  get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public Categoria Categoria { get; set; }
        public bool RequiereStock { get; set; }
        public int Stock {  get; set; } 

    }
}
