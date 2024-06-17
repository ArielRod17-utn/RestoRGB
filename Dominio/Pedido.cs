using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
       public int NumeroPedido { get; set; }
       public int NumeroMesa {  get; set; }
        public decimal Total { get; set; }
        public int IdUsuario { get; set; }
    
    }
}
