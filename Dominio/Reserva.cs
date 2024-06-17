using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reserva
    {
        public int NumeroMesa { get; set; }   
        public DateTime? FechaReserva { get; set; }
        public String dniCliente { get; set; }

    }
}
