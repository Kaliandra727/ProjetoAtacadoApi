using Atacado.Poco.Estoque;
using Atacado.EF.Database;
using Atacado.Mapper.Estoque;
using Atacado.Service.Ancestral;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atacado.Dal.Estoque;

namespace Atacado.Service.Estoque
{
    public class CategoriaService : BaseAncestralService<CategoriaPoco>
    {
        private CategoriaMapper mapConfig;
        private CategoriaDao dao;

        public CategoriaService()
        {
            this.mapConfig = new CategoriaMapper();
            this.dao = new CategoriaDao();
        }

        public override List<CategoriaPoco> Listar()
        {
            List<Categoria> listDom = this.dao.ReadAll();
            List<CategoriaPoco> listPoco = new List<CategoriaPoco>();
            foreach (Categoria item in listDom)
            {
                CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(item);
                listPoco.Add(poco);
            }                
            return listPoco;
        }

        public override CategoriaPoco Selecionar(int id)
        {
            Categoria dom = this.dao.Read(id);
            CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(dom);
            return poco;
        }
    }
}