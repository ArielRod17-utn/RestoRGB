using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EstadoMesa
    {
        public int idEstadoMesa { get; set; }  // este no tocar . solo se hace el insert into en la base de datos
        public string Descripcion { get; set; }

    }
}
