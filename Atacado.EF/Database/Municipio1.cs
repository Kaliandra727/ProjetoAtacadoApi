using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Keyless]
    [Table("Municipio1")]
    public partial class Municipio1
    {
        [Column("ID_Municipio")]
        public int IdMunicipio { get; set; }
        [Column("Nome_Municipio")]
        [Unicode(false)]
        public string? NomeMunicipio { get; set; }
        [Column("ID_UF")]
        public int IdUf { get; set; }
        [Column("Sigla_UF")]
        [StringLength(2)]
        [Unicode(false)]
        public string? SiglaUf { get; set; }
        [Column("ID_Mesoregiao")]
        public int IdMesoregiao { get; set; }
        [Column("ID_Microregiao")]
        public int IdMicroregiao { get; set; }
        [Column("Cod_Ibge")]
        public long CodIbge { get; set; }
        [Column("Cod_Ibge7")]
        public long CodIbge7 { get; set; }
        public long? Populacao { get; set; }
        [Unicode(false)]
        public string? Porte { get; set; }
        public long? Cep { get; set; }
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}
