using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.IBGE
{
    public class MunicipioRepository : BaseRepository<Municipio>
    {
        public MunicipioRepository(AtacadoContext contexto) : base(contexto)
        {
        }

        public override Municipio DeleteById(int id)
        {
            Municipio mun = this.Read(id);
            this.context.Set<Municipio>().Remove(mun);
            this.context.SaveChanges();
            return mun;
        }
    }
}
