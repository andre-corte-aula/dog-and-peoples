using DogAndPeoples.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Domain.Interfaces
{
    public interface IDonosRepository
    {
        int Atualizar(Donos donos);
        int Adicionar(Donos donos);
        IEnumerable<Donos> Listar(Donos donos);
        Donos Obter(Donos donos);
    }
}
