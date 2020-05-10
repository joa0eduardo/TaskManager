using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UsuarioTempoDia
    {
        public int IdUsuarioTempoDia { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataUsuarioTempoDia { get; set; }
        public DateTime TotalUsuarioTempoDia { get; set; }
    }
}
