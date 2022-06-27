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
    public class TipoRebanhoRepository : BaseRepository<TipoRebanho>
    {
        public TipoRebanhoRepository(AtacadoContext contexto) : base(contexto)
        {
        }

        public override TipoRebanho DeleteById(int id)
        {
            TipoRebanho tipo = this.Read(id);
            this.context.Set<TipoRebanho>().Remove(tipo);
            this.context.SaveChanges();
            return tipo;
        }
    }
}
