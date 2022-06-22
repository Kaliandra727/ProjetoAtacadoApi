using Atacado.Dal.Auxiliar;
using Atacado.EF.Database;
using Atacado.Mapper.Auxiliar;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Auxiliar
{
    public class CursoService : BaseAncestralService<CursoPoco>
    {
        private CursoMapper mapConfig;
        private CursoDao dao;

        public CursoService()
        {
            this.mapConfig = new CursoMapper();
            this.dao = new CursoDao();
        }

        public override List<CursoPoco> Listar()
        {
            List<Curso> listDom = this.dao.ReadAll().Skip(0).Take(100).ToList();
            List<CursoPoco> listPoco = new List<CursoPoco>();
            foreach (Curso item in listDom)
            {
                CursoPoco poco = this.mapConfig.Mapper.Map<CursoPoco>(item);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override CursoPoco Selecionar(int id)
        {
            Curso dom = this.dao.Read(id);
            CursoPoco poco = this.mapConfig.Mapper.Map<CursoPoco>(dom);
            return poco;
        }

        public override CursoPoco Criar(CursoPoco obj)
        {
            Curso dom = this.mapConfig.Mapper.Map<Curso>(obj);
            Curso criado = this.dao.Create(dom);
            CursoPoco poco = this.mapConfig.Mapper.Map<CursoPoco>(criado);
            return poco;
        }

        public List<CursoPoco> Listar(int pular, int exibir)
        {
            List<Curso> listDom = this.dao.ReadAll(pular, exibir);
            return ProcessarListaDOM(listDom);
        }

        private List<CursoPoco> ProcessarListaDOM(List<Curso> listDom)
        {
            List<CursoPoco> listPoco = new List<CursoPoco>();
            foreach (Curso item in listDom)
            {
                CursoPoco poco = this.mapConfig.Mapper.Map<CursoPoco>(item);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override CursoPoco Atualizar(CursoPoco obj)
        {
            Curso dom = this.mapConfig.Mapper.Map<Curso>(obj);
            Curso atualizado = this.dao.Update(dom);
            CursoPoco poco = this.mapConfig.Mapper.Map<CursoPoco>(atualizado);
            return poco;
        }

        public override CursoPoco Excluir(CursoPoco obj)
        {
            return this.Excluir(obj.IdCursos);
        }

        public override CursoPoco Excluir(int id)
        {
            Curso excluido = this.dao.Delete(id);
            CursoPoco poco = this.mapConfig.Mapper.Map<CursoPoco>(excluido);
            return poco;
        }
    }
}
