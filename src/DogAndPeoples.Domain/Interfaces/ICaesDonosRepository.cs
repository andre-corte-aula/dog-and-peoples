using DogAndPeoples.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Domain.Interfaces
{
    public interface ICaesDonosRepository
    {
        int Adicionar(CaesDono caesDono);
        CaesDono Obter(CaesDono caesDono);
    }
}
