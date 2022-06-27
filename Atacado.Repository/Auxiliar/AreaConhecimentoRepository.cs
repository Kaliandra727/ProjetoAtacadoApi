using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.Auxiliar
{
    public class AreaConhecimentoRepository : BaseRepository<AreaConhecimento>
    {
        public AreaConhecimentoRepository(AtacadoContext contexto) : base(contexto)
        {
        }

        public override AreaConhecimento DeleteById(int id)
        {
            AreaConhecimento area = this.Read(id);
            this.context.Set<AreaConhecimento>().Remove(area);
            this.context.SaveChanges();
            return area;
        }
    }
}
