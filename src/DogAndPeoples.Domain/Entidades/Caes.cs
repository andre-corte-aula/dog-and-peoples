﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Domain.Entidades
{
    public class Caes
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public virtual ICollection<CaesDono> CaesDonos { get; set; }
    }
}
