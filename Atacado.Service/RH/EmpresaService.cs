using Atacado.EF.Database;
using Atacado.Mapper.Ancestral;
using Atacado.Poco.RH;
using Atacado.Repository.RH;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.RH
{
    public class EmpresaService : BaseAncestralService<EmpresaPoco, Empresa>
    {
        private EmpresaRepository repositorio;

        public EmpresaService() : base()
        {
            this.mapeador = new MapeadorGenerico<EmpresaPoco, Empresa>();
            this.repositorio = new EmpresaRepository(new AtacadoContext());
        }

        public List<EmpresaPoco> Listar(int pular, int exibir)
        {
            List<Empresa> listDom = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listDom);
        }

        protected override List<EmpresaPoco> ProcessarListaDOM(List<Empresa> listDOM)
        {
            return listDOM.Select(dom => this.mapeador.Mecanismo.Map<EmpresaPoco>(dom)).ToList();
        }

        public override EmpresaPoco Selecionar(int id)
        {
            Empresa dom = this.repositorio.Read(id);
            EmpresaPoco poco = this.mapeador.Mecanismo.Map<EmpresaPoco>(dom);
            return poco;
        }

        public override EmpresaPoco Criar(EmpresaPoco obj)
        {
            Empresa dom = this.mapeador.Mecanismo.Map<Empresa>(obj);
            Empresa criado = this.repositorio.Add(dom);
            EmpresaPoco poco = this.mapeador.Mecanismo.Map<EmpresaPoco>(criado);
            return poco;
        }

        public override EmpresaPoco Atualizar(EmpresaPoco obj)
        {
            Empresa dom = this.mapeador.Mecanismo.Map<Empresa>(obj);
            Empresa atualizado = this.repositorio.Edit(dom);
            EmpresaPoco poco = this.mapeador.Mecanismo.Map<EmpresaPoco>(atualizado);
            return poco;
        }

        public override EmpresaPoco Excluir(EmpresaPoco obj)
        {
            Empresa temp = this.mapeador.Mecanismo.Map<Empresa>(obj);
            Empresa excluido = this.repositorio.Delete(temp);
            EmpresaPoco poco = this.mapeador.Mecanismo.Map<EmpresaPoco>(excluido);
            return poco;
        }

        public override EmpresaPoco Excluir(int id)
        {
            Empresa excluido = this.repositorio.DeleteById(id);
            EmpresaPoco poco = this.mapeador.Mecanismo.Map<EmpresaPoco>(excluido);
            return poco;
        }
    }
}
