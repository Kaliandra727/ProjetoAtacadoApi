using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.IBGE
{
    public class MunicipioRepository : BaseRepository<Municipio1>
    {
        public MunicipioRepository(AtacadoContext contexto) : base(contexto)
        {
        }

        public override Municipio1 DeleteById(int id)
        {
            Municipio1 mun = this.Read(id);
            this.context.Set<Municipio1>().Remove(mun);
            this.context.SaveChanges();
            return mun;
        }
    }
}
