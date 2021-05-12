using DogAndPeoples.Domain.Entidades;
using DogAndPeoples.Domain.Interfaces;
using DogAndPeoples.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Application.Services
{
    public class CaesDonosService : ICaesDonosService
    {
        private readonly IDonosRepository _donosRepository;
        private readonly ICaesRepository _caesRepository;
        private readonly ICaesDonosRepository _caesDonosRepository;

        public CaesDonosService(IDonosRepository donosRepository, ICaesRepository caesRepository, ICaesDonosRepository caesDonosRepository)
        {
            _donosRepository = donosRepository;
            _caesRepository = caesRepository;
            _caesDonosRepository = caesDonosRepository;
        }

        public void Adicionar(CaesViewModel donos)
        {
            List<string> vs = new List<string>(0);

            if (string.IsNullOrWhiteSpace(donos.Nome))
            {
                vs.Add("Nome");
            }
            if (string.IsNullOrWhiteSpace(donos.NomeDono))
            {
                vs.Add("Nome do dono");
            }
            if (string.IsNullOrWhiteSpace(donos.Raca))
            {
                vs.Add("Raça");
            }

            if (vs.Any())
            {
                throw new Exception($"Informe os campos obrigatórios: {string.Join(", ", vs)}");
            }

            // adicionar donos
            int idDonos = _donosRepository.Adicionar(new Donos
            {
                Nome = donos.NomeDono
            });

            // adicionar caes
            int idCaes = _caesRepository.Adicionar(new Caes
            {
                Nome = donos.Nome,
                Raca = donos.Raca,
            });

            // relacionar caes e donos
            _caesDonosRepository.Adicionar(new CaesDono
            {
                IdCaes = idCaes,
                IdDono = idDonos
            });
        }

        public void Atualizar(CaesViewModel donos)
        {
            List<string> vs = new List<string>(0);

            if (donos.Id == 0)
            {
                vs.Add("Id do cão");
            }
            if (donos.IdDono == 0)
            {
                vs.Add("Id do dono");
            }
            if (string.IsNullOrWhiteSpace(donos.Nome))
            {
                vs.Add("Nome");
            }
            if (string.IsNullOrWhiteSpace(donos.NomeDono))
            {
                vs.Add("Nome do dono");
            }
            if (string.IsNullOrWhiteSpace(donos.Raca))
            {
                vs.Add("Raça");
            }

            if (vs.Any())
            {
                throw new Exception($"Informe os campos obrigatórios: {string.Join(", ", vs)}");
            }

            // adicionar donos
            _donosRepository.Atualizar(new Donos
            {
                Id = donos.IdDono,
                Nome = donos.NomeDono
            });

            // adicionar caes
            _caesRepository.Atualizar(new Caes
            {
                Id = donos.Id,
                Nome = donos.Nome,
                Raca = donos.Raca,
            });
        }

        public IEnumerable<CaesViewModel> Listar(string nomeCao, string raca)
        {
            nomeCao = string.IsNullOrWhiteSpace(nomeCao) ? null : nomeCao;
            raca = string.IsNullOrWhiteSpace(raca) ? null : raca;

            // obter lista de donos
            IEnumerable<CaesViewModel> caes = _caesRepository.Listar(nomeCao, raca);

            return caes;
        }

        public CaesViewModel Obter(long id)
        {
            return _caesRepository.Obter(id);
        }

        public void Remover(long id, long idDono)
        {
            _caesRepository.Remover(id, idDono);
        }
    }
}
