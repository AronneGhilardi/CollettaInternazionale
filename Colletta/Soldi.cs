using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colletta
{
    public class Soldi : IComparable<Soldi>
    {
        public double Importo { get; set; }

        public Soldi(double importo)
        {
            Importo = importo;
        }

        public int CompareTo(Soldi other)
        {
            return Importo.CompareTo(other.Importo);
        }
    }
}
