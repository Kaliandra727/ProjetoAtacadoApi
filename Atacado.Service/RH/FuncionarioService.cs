﻿using Atacado.Business.RH;
using Atacado.EF.Database;
using Atacado.Mapper.Ancestral;
using Atacado.Poco.RH;
using Atacado.Repository.RH;
using Atacado.Service.Ancestral;

namespace Atacado.Service.RH
{
    public class FuncionarioService : BaseAncestralService<FuncionarioPoco, Funcionario>
    {

        private FuncionarioRepository repositorio;
        private FuncionarioRegra regra;

        public FuncionarioService() : base()
        {
            this.mapeador = new MapeadorGenerico<FuncionarioPoco, Funcionario>(); 
            this.repositorio = new FuncionarioRepository(new AtacadoContext());
            this.regra = new FuncionarioRegra();
        }

        public List<FuncionarioPoco> Listar(int pular, int exibir)
        {
            List<Funcionario> listDom = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listDom);
        }

        protected override List<FuncionarioPoco> ProcessarListaDOM(List<Funcionario> listDOM)
        {
            return listDOM.Select(dom => this.mapeador.Mecanismo.Map<FuncionarioPoco>(dom)).ToList();
        }

        public override FuncionarioPoco Selecionar(int id)
        {
            Funcionario dom = this.repositorio.Read(id);
            FuncionarioPoco poco = this.mapeador.Mecanismo.Map<FuncionarioPoco>(dom);
            return poco;
        }

        public FuncionarioPoco SelecionarPorMatricula(long mat)
        {
            Funcionario busca = this.repositorio.Browse(fun => fun.Matricula == mat).First();
            FuncionarioPoco poco = this.mapeador.Mecanismo.Map<FuncionarioPoco>(busca);
            return poco;
        }

        public override FuncionarioPoco Criar(FuncionarioPoco obj)
        {
            this.regra.Poco = obj;
            if (this.regra.Process() == false)
            {
                this.mensagemProcessamento.AddRange(this.regra.RuleMessages);
                return null;
            }
            else
            {
                Funcionario dom = this.mapeador.Mecanismo.Map<Funcionario>(obj);
                Funcionario criado = this.repositorio.Add(dom);
                FuncionarioPoco poco = this.mapeador.Mecanismo.Map<FuncionarioPoco>(criado);
                return poco;
            }
           
        }

        public override FuncionarioPoco Atualizar(FuncionarioPoco obj)
        {
            this.regra.Poco = obj;
            if (this.regra.Process() == false)
            {
                this.mensagemProcessamento.AddRange(this.regra.RuleMessages);
                return null;
            }
            else
            {
                Funcionario dom = this.mapeador.Mecanismo.Map<Funcionario>(obj);
                Funcionario atualizado = this.repositorio.Edit(dom);
                FuncionarioPoco poco = this.mapeador.Mecanismo.Map<FuncionarioPoco>(atualizado);
                return poco;
            }
        }

        public override FuncionarioPoco Excluir(FuncionarioPoco obj)
        {
            Funcionario temp = this.mapeador.Mecanismo.Map<Funcionario>(obj);
            Funcionario excluido = this.repositorio.Delete(temp);
            FuncionarioPoco poco = this.mapeador.Mecanismo.Map<FuncionarioPoco>(excluido);
            return poco;
        }

        public override FuncionarioPoco Excluir(int id)
        {
            Funcionario excluido = this.repositorio.DeleteById(id);
            FuncionarioPoco poco = this.mapeador.Mecanismo.Map<FuncionarioPoco>(excluido);
            return poco;
        }
    }
}
