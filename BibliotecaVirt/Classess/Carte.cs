using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirt.Classess
{
    public class Carte
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string ISBN { get; set; }
        public decimal PretInchiriere { get; set; }
        public int NumarExmeplare { get; set; }
    }
}
