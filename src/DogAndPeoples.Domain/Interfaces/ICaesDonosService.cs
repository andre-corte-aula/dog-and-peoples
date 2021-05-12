using DogAndPeoples.Domain.Entidades;
using DogAndPeoples.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Domain.Interfaces
{
    public interface ICaesDonosService
    {
        void Atualizar(CaesViewModel donos);
        void Remover(long id, long idDono);
        void Adicionar(CaesViewModel caes);
        IEnumerable<CaesViewModel> Listar(string nomeCao, string raca);
        CaesViewModel Obter(long id);
    }
}
