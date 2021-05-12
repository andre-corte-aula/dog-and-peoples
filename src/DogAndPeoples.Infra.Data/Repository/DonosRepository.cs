using DogAndPeoples.Domain.Entidades;
using DogAndPeoples.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Infra.Data.Repository
{
    public class DonosRepository : BaseRepository, IDonosRepository
    {
        public int Adicionar(Donos donos)
        {
            string sql = @"insert into Donos (
	                            Nome
                            ) values (
	                            @Nome
                            );

                            select scope_identity()";

            return base.Adicionar(sql, donos);
        }
        
        public int Atualizar(Donos donos)
        {
            string sql = @"update Donos set
                                Nome = @Nome
                            where Id = @Id;";

            return base.Adicionar(sql, donos);
        }

        public IEnumerable<Donos> Listar(Donos caes)
        {
            string sql = @"select * from Donos d
	                        where (@Nome is null or d.Nome like '%'+@Nome+'%');";

            return base.Listar<Donos>(sql, caes);
        }

        public Donos Obter(Donos caes)
        {
            string sql = @"select * from Donos d where d.Id = @Id;";
            return base.Obter<Donos>(sql, caes);
        }
    }
}
