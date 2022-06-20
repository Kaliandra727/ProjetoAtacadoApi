using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    public partial class Curso
    {
        [Key]
        [Column("ID_Cursos")]
        public int IdCursos { get; set; }
        [Column("Descricao_Cursos")]
        [Unicode(false)]
        public string? DescricaoCursos { get; set; }
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}
