using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Mesoregiao")]
    public partial class Mesoregiao
    {
        [Key]
        [Column("ID_Mesoregiao")]
        public int IdMesoregiao { get; set; }
        [Column("Descricao_Mesoregiao")]
        [StringLength(100)]
        [Unicode(false)]
        public string? DescricaoMesoregiao { get; set; }
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
