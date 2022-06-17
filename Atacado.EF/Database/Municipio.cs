using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Municipio")]
    public partial class Municipio
    {
        [Key]
        [Column("ID_Municipio")]
        public int IdMunicipio { get; set; }
        [Column("Codigo_Ibge_6")]
        public long CodigoIbge6 { get; set; }
        [Column("Codigo_Ibge_7")]
        public long CodigoIbge7 { get; set; }
        [Column("Nome_Municipio")]
        [Unicode(false)]
        public string NomeMunicipio { get; set; } = null!;
        [Column("ID_Mesoregiao")]
        public int IdMesoregiao { get; set; }
        [Column("ID_Microregiao")]
        public int IdMicroregiao { get; set; }
        [Column("ID_Unidade_Federacao")]
        public int IdUnidadeFederacao { get; set; }
        [Column("SiglaUF")]
        [StringLength(2)]
        [Unicode(false)]
        public string SiglaUf { get; set; } = null!;
        [Column("Populacao_Municipio")]
        public long? PopulacaoMunicipio { get; set; }
        [Column("Porte_Municipio")]
        [Unicode(false)]
        public string PorteMunicipio { get; set; } = null!;
        [Column("Cep_Municipio")]
        public int? CepMunicipio { get; set; }
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }

        [ForeignKey("IdMesoregiao")]
        [InverseProperty("Municipios")]
        public virtual Mesoregiao IdMesoregiaoNavigation { get; set; } = null!;
        [ForeignKey("IdMicroregiao")]
        [InverseProperty("Municipios")]
        public virtual Microregiao IdMicroregiaoNavigation { get; set; } = null!;
        [ForeignKey("IdUnidadeFederacao")]
        [InverseProperty("MunicipioIdUnidadeFederacaoNavigations")]
        public virtual UnidadeFederacao IdUnidadeFederacaoNavigation { get; set; } = null!;
        public virtual UnidadeFederacao SiglaUfNavigation { get; set; } = null!;
    }
}
