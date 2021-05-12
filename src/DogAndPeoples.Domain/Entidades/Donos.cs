using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Domain.Entidades
{
    public class Donos
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public virtual CaesDono CaesDonos { get; set; }
    }
}
