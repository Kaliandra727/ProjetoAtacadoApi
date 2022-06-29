using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.RH
{
    public class EmpresaRepository : BaseRepository<Empresa>
    {
        public EmpresaRepository(DbContext context) : base(context)
        {
        }

        public override Empresa DeleteById(int id)
        {
            Empresa emp = this.Read(id);
            this.context.Set<Empresa>().Remove(emp);
            this.context.SaveChanges();
            return emp;
        }
    }
}
