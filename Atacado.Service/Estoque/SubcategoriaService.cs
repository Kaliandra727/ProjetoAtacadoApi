using Atacado.Dal.Estoque;
using Atacado.EF.Database;
using Atacado.Mapper.Estoque;
using Atacado.Poco.Estoque;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Estoque
{
    public class SubcategoriaService : BaseAncestralService<SubcategoriaPoco>
    {
        private SubcategoriaMapper mapConfig;
        private SubcategoriaDao dao;

        public SubcategoriaService()
        {
            this.mapConfig = new SubcategoriaMapper();
            this.dao = new SubcategoriaDao();
        }

        public override List<SubcategoriaPoco> Listar()
        {
            List<Subcategoria> listDom = this.dao.ReadAll();
            List<SubcategoriaPoco> listPoco = new List<SubcategoriaPoco>();
            foreach (Subcategoria item in listDom)
            {
                SubcategoriaPoco poco = this.mapConfig.Mapper.Map<SubcategoriaPoco>(item);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override SubcategoriaPoco Selecionar(int id)
        {
            Subcategoria dom = this.dao.Read(id);
            SubcategoriaPoco poco = this.mapConfig.Mapper.Map<SubcategoriaPoco>(dom);
            return poco;
        }
    }
}
