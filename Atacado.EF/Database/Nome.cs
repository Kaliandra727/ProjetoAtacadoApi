﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Nome")]
    public partial class Nome
    {
        [Key]
        [Column("ID_Nome")]
        public int IdNome { get; set; }
        [Column("Nome")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Nome1 { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? Sexo { get; set; }
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}
