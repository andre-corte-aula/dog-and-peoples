using DogAndPeoples.Domain.Entidades;
using DogAndPeoples.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Infra.Data.Repository
{
    public class CaesDonosRepository : BaseRepository, ICaesDonosRepository
    {
        public int Adicionar(CaesDono caesDono)
        {
            string sql = @"insert into CaesDono (
	                            IdDono,
	                            IdCaes
                            ) values (
	                            @IdDono,
	                            @IdCaes
                            );";

            return base.Adicionar(sql, caesDono);
        }

        public CaesDono Obter(CaesDono caesDono)
        {
            string sql = @"select * from CaesDono d where d.IdDonos = @IdDonos;";
            return base.Obter<CaesDono>(sql, caesDono);
        }
    }
}
