using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Microregiao")]
    public partial class Microregiao
    {
        [Key]
        [Column("ID_MicroRegiao")]
        public int IdMicroRegiao { get; set; }
        [Column("Descricao_Microregiao")]
        [StringLength(100)]
        [Unicode(false)]
        public string? DescricaoMicroregiao { get; set; }
        [Column("Sigla_UF")]
        [StringLength(2)]
        [Unicode(false)]
        public string? SiglaUf { get; set; }
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }

        public virtual UnidadesFederacao? SiglaUfNavigation { get; set; }
    }
}
