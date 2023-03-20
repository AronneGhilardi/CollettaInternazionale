using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colletta
{
    public class Persona : IComparable<Persona>
    {
        string nome, id;

        public string Nome { get; set; }
     
        public string Id { get; set; }
        Random rnd = new Random();

        public Persona(string nome)
        {
            Nome = nome;
            Id = nome+rnd.Next(0,100);
        }

        public bool Equals(Persona p)
        {
            if (p == null) return false;
            if (this == p) return true;
            return (this.Id == p.Id);
        }

        public override int GetHashCode()
        {
            return (Id, Nome).GetHashCode();
        }

        public int CompareTo(Persona other)
        {
            return Nome.CompareTo(other.Nome);
        }
    }
}
