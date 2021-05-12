using DogAndPeoples.Domain.Entidades;
using DogAndPeoples.Domain.Interfaces;
using DogAndPeoples.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Infra.Data.Repository
{
    public class CaesRepository : BaseRepository, ICaesRepository
    {
        public int Adicionar(Caes caes)
        {
            string sql = @"insert into Caes (
	                            Nome,
	                            Raca
                            ) values (
	                            @Nome,
	                            @Raca
                            );

                            select scope_identity()";

            return base.Adicionar(sql, caes);
        }

        public int Atualizar(Caes caes)
        {
            string sql = @"update Caes set
                                Nome = @Nome,
                                Raca = @Raca
                            where Id = @Id;";

            return base.Adicionar(sql, caes);
        }

        public IEnumerable<CaesViewModel> Listar(string nome, string raca)
        {
            string sql = @"select c.*, d.Nome as NomeDono, d.Id as IdDono from Caes c
	                            join CaesDono cd on cd.IdCaes = c.Id
	                            join Donos d on d.Id = cd.IdDono
	                            where (@Nome is null or lower(c.Nome) like '%'+lower(@Nome)+'%') and (@Raca is null or lower(c.Raca) like '%'+lower(@Raca)+'%')";
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>
            {
                { "@Nome", nome },
                { "@Raca", raca },
            };
            return base.Listar<CaesViewModel>(sql, keyValuePairs);
        }

        public CaesViewModel Obter(long id)
        {
            string sql = @"select c.*, d.Nome as NomeDono, d.Id as IdDono from Caes c
	                            join CaesDono cd on cd.IdCaes = c.Id
	                            join Donos d on d.Id = cd.IdDono
	                            where c.Id = @Id;";
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>
            {
                { "@Id", id }
            };
            return base.Obter<CaesViewModel>(sql, keyValuePairs);
        }

        public void Remover(long id, long idDono)
        {
            string sql = @"delete from CaesDono where IdDono = @IdDono and IdCaes = @Id;
                            delete from Caes where id = @Id;
                            delete from Donos where id = @IdDono;";
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>
            {
                { "@Id", id },
                { "@IdDono", idDono },
            };
            base.Remover(sql, keyValuePairs);
        }
    }
}
