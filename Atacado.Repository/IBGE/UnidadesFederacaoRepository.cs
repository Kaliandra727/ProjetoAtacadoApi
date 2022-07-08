using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.IBGE
{
    public class UnidadesFederacaoRepository : BaseRepository<UnidadesFederacao>
    {
        public UnidadesFederacaoRepository(AtacadoContext contexto) : base(contexto)
        {
        }

        public override UnidadesFederacao DeleteById(int id)
        {
            UnidadesFederacao uf = this.Read(id);
            this.context.Set<UnidadesFederacao>().Remove(uf);
            this.context.SaveChanges();
            return uf;
        }
    }
}
