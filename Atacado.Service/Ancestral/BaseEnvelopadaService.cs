using Atacado.Mapper.Ancestral;

namespace Atacado.Service.Ancestral
{
    public class BaseEnvelopadaService<TPoco, TDom, TEnvelope>
        where TPoco : class
        where TDom : class
        where TEnvelope : class
    {
        protected MapeadorGenericoEnvelopado<TPoco, TDom, TEnvelope> mapeador;

        protected List<string> mensagemProcessamento;

        public List<string> MensagemProcessamento => this.mensagemProcessamento;

        public BaseEnvelopadaService()
        {
            this.mensagemProcessamento = new List<string>();
        }

        public virtual List<TEnvelope> Listar()
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }

        public virtual TEnvelope Selecionar(int id)
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }

        public virtual TEnvelope Criar(TPoco obj)
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }

        public virtual TEnvelope Atualizar(TPoco obj)
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }

        public virtual TEnvelope Excluir(TPoco obj)
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }

        public virtual TEnvelope Excluir(int id)
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }

        protected virtual List<TEnvelope> ProcessarListaDOM(List<TDom> listDOM)
        {
            throw new NotImplementedException("Vai copiar Código da sua vó!!");
        }
    }
}

