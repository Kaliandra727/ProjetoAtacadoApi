using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Unidade_Federacao")]
    [Index("SiglaUf", Name = "AK_Unidade_Federacao", IsUnique = true)]
    public partial class UnidadeFederacao
    {
        public UnidadeFederacao()
        {
            Distritos = new HashSet<Distrito>();
            Mesoregiaos = new HashSet<Mesoregiao>();
            Microregiaos = new HashSet<Microregiao>();
            MunicipioIdUnidadeFederacaoNavigations = new HashSet<Municipio>();
            MunicipioSiglaUfNavigations = new HashSet<Municipio>();
            SubDistritos = new HashSet<SubDistrito>();
        }

        [Key]
        [Column("ID_Unidade_Federacao")]
        public int IdUnidadeFederacao { get; set; }
        [Column("Descricao_Unidade_Federacao")]
        [Unicode(false)]
        public string DescricaoUnidadeFederacao { get; set; } = null!;
        [Column("SiglaUF")]
        [StringLength(2)]
        [Unicode(false)]
        public string SiglaUf { get; set; } = null!;
        [Column("Regiao_Brasil")]
        [Unicode(false)]
        public string RegiaoBrasil { get; set; } = null!;
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
        [InverseProperty("IdUnidadeFederacaoNavigation")]
        public virtual ICollection<Municipio> MunicipioIdUnidadeFederacaoNavigations { get; set; }
        public virtual ICollection<Municipio> MunicipioSiglaUfNavigations { get; set; }
        public virtual ICollection<SubDistrito> SubDistritos { get; set; }
    }
}
