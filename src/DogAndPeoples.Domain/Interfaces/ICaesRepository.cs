using DogAndPeoples.Domain.Entidades;
using DogAndPeoples.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Domain.Interfaces
{
    public interface ICaesRepository
    {
        int Atualizar(Caes caes);
        void Remover(long id, long idDono);
        int Adicionar(Caes caes);
        IEnumerable<CaesViewModel> Listar(string nome, string raca);
        CaesViewModel Obter(long id);
    }
}
