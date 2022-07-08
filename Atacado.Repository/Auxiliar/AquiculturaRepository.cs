using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.Auxiliar
{
    public class AquiculturaRepository : BaseRepository<Aquicultura>
    {
        public AquiculturaRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Aquicultura DeleteById(int id)
        {
            Aquicultura aquicultura = this.Read(id);
            this.context.Set<Aquicultura>().Remove(aquicultura);
            this.context.SaveChanges();
            return aquicultura;
        }
    }
}
