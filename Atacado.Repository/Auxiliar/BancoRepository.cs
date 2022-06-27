﻿using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.Auxiliar
{
    public class BancoRepository : BaseRepository<Banco>
    {
        public BancoRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Banco DeleteById(int id)
        {
            Banco banco = this.Read(id);
            this.context.Set<Banco>().Remove(banco);
            this.context.SaveChanges();
            return banco;
        }
    }
}
