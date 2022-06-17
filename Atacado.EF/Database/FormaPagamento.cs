using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Forma_Pagamento")]
    public partial class FormaPagamento
    {
        public FormaPagamento()
        {
            Pedidos = new HashSet<Pedido>();
        }

        [Key]
        [Column("ID_Forma_Pagamento")]
        public int IdFormaPagamento { get; set; }
        [Column("ID_Tipo_Forma_Pagamento")]
        public int IdTipoFormaPagamento { get; set; }
        [Column("Descricao_Forma_Pagamento")]
        [Unicode(false)]
        public string DescricaoFormaPagamento { get; set; } = null!;
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }

        [ForeignKey("IdTipoFormaPagamento")]
        [InverseProperty("FormaPagamentos")]
        public virtual TipoFormaPagamento IdTipoFormaPagamentoNavigation { get; set; } = null!;
        [InverseProperty("IdFormaPagamentoNavigation")]
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
