using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Business.Ancestral
{
    public interface IRule
    {
        List<string> RuleMessages { get; }

        bool Process();
    }
}
