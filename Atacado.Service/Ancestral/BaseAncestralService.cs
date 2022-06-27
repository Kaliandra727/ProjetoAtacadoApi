using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Ancestral
{
    public abstract class BaseAncestralService<TPoco, TDom> 
        where TPoco : class
        where TDom : class
    {
        public virtual List<TPoco> Listar()
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }

        public virtual TPoco Selecionar(int id)
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }

        public virtual TPoco Criar(TPoco obj)
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }

        public virtual TPoco Atualizar(TPoco obj)
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }

        public virtual TPoco Excluir(TPoco obj)
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }

        public virtual TPoco Excluir(int id)
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }

        protected virtual List<TPoco> ProcessarListaDOM(List<TDom> listDOM)
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }
    }
}