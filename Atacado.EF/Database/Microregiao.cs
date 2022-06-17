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
        public Microregiao()
        {
            Municipios = new HashSet<Municipio>();
        }

        [Key]
        [Column("ID_Microregiao")]
        public int IdMicroregiao { get; set; }
        [Column("Descricao_Microregiao")]
        [Unicode(false)]
        public string DescricaoMicroregiao { get; set; } = null!;
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
        [InverseProperty("IdMicroregiaoNavigation")]
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
