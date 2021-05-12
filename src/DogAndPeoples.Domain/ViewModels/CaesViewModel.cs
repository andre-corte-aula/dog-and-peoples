using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Domain.ViewModels
{
    public class CaesViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public long IdDono { get; set; }
        public string NomeDono { get; set; }
    }
}
