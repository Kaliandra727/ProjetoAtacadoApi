using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Primeiro_Nome")]
    public partial class PrimeiroNome
    {
        [Key]
        [Column("ID_Primeiro_Nome")]
        public int IdPrimeiroNome { get; set; }
        [Column("Primeiro_Nome")]
        [Unicode(false)]
        public string PrimeiroNome1 { get; set; } = null!;
        [Column("Sexo_Primeiro_Nome")]
        [StringLength(1)]
        [Unicode(false)]
        public string SexoPrimeiroNome { get; set; } = null!;
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}
