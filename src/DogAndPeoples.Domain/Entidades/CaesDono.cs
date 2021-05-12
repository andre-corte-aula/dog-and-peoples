using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Domain.Entidades
{
    public class CaesDono
    {
        public long IdDono { get; set; }
        public long IdCaes { get; set; }
        public virtual ICollection<Caes> Caes { get; set; }
        public virtual Donos Donos { get; set; }
    }
}
