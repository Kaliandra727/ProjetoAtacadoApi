using Atacado.Business.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Business.RH
{
    public class TesteRegra : IRule
    {
        private List<string> ruleMessages;
        public List<string> RuleMessages => this.RuleMessages;

        public TesteRegra()
        {
            this.ruleMessages = new List<string>();
        }

        public bool Process()
        {
            throw new NotImplementedException();
        }

        private bool Regra1()
        { 
            
        }

        private bool Regra2()
        { }

        private bool Regra3()
        { }

        private bool Regra4()
        { }

        private bool Regra5()
        { }

    }
}
