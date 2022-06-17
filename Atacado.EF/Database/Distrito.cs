using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Distrito")]
    public partial class Distrito
    {
        [Key]
        [Column("ID_Distrito")]
        public int IdDistrito { get; set; }
        [Column("Descricao_Distrito")]
        [Unicode(false)]
        public string DescricaoDistrito { get; set; } = null!;
        [Column("SiglaUF")]
        [StringLength(2)]
        [Unicode(false)]
        public string SiglaUf { get; set; } = null!;
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }

        public virtual UnidadeFederacao SiglaUfNavigation { get; set; } = null!;
    }
}
