using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Tipo_Forma_Pagamento")]
    public partial class TipoFormaPagamento
    {
        public TipoFormaPagamento()
        {
            FormaPagamentos = new HashSet<FormaPagamento>();
        }

        [Key]
        [Column("ID_Tipo_Forma_Pagamento")]
        public int IdTipoFormaPagamento { get; set; }
        [Column("Descricao_Tipo_Forma_Pagamento")]
        [Unicode(false)]
        public string DescricaoTipoFormaPagamento { get; set; } = null!;
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }

        [InverseProperty("IdTipoFormaPagamentoNavigation")]
        public virtual ICollection<FormaPagamento> FormaPagamentos { get; set; }
    }
}
