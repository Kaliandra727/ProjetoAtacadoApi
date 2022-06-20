using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Unidades_Federacao")]
    [Index("SiglaUf", Name = "AK_Unidade_Federacao", IsUnique = true)]
    public partial class UnidadesFederacao
    {
        public UnidadesFederacao()
        {
            Distritos = new HashSet<Distrito>();
            Mesoregiaos = new HashSet<Mesoregiao>();
            Microregiaos = new HashSet<Microregiao>();
            SubDestritos = new HashSet<SubDestrito>();
        }

        [Key]
        [Column("ID_Unidades_Federacao")]
        public int IdUnidadesFederacao { get; set; }
        [Column("Descricao_Unidades_Federacao")]
        [StringLength(100)]
        [Unicode(false)]
        public string? DescricaoUnidadesFederacao { get; set; }
        [Column("Sigla_UF")]
        [StringLength(2)]
        [Unicode(false)]
        public string SiglaUf { get; set; } = null!;
        [Column("Regiao_Brasil")]
        [StringLength(20)]
        [Unicode(false)]
        public string? RegiaoBrasil { get; set; }
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }

        public virtual ICollection<Distrito> Distritos { get; set; }
        public virtual ICollection<Mesoregiao> Mesoregiaos { get; set; }
        public virtual ICollection<Microregiao> Microregiaos { get; set; }
        public virtual ICollection<SubDestrito> SubDestritos { get; set; }
    }
}
