using Atacado.Business.Ancestral;
using Atacado.Poco.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Business.RH
{
    public class FuncionarioRegra : IRule
    {
        private List<string> ruleMessages;

        private FuncionarioPoco poco;

        public List<string> RuleMessages => this.ruleMessages;

        public FuncionarioRegra(FuncionarioPoco poco)
        {
            this.ruleMessages = new List<string>();
            this.poco = poco;
        }

        public bool Process()
        {
            bool resultado = true;

            if(this.NomeRegra() == false)
            {
                resultado = false;
            }

            return resultado;
        }

        private bool NomeRegra()
        {
            if (string.IsNullOrEmpty(this.poco.Nome) == true)
            {
                this.ruleMessages.Add("Nome não pode ser vazio.");
                return false;
            }
            else
                return true;
        }


    }
}
