using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Keyless]
    [Table("RAW_DATA_Lista_de_Municipio")]
    public partial class RawDataListaDeMunicipio
    {
        [Column("ConcatUF_Mun")]
        [StringLength(100)]
        public string ConcatUfMun { get; set; } = null!;
        [Column("IBGE")]
        public int Ibge { get; set; }
        [Column("IBGE7")]
        public int Ibge7 { get; set; }
        [Column("UF")]
        [StringLength(50)]
        public string Uf { get; set; } = null!;
        [StringLength(100)]
        public string Municipio { get; set; } = null!;
        [StringLength(50)]
        public string Região { get; set; } = null!;
        [Column("Populacao_2010")]
        public int? Populacao2010 { get; set; }
        [StringLength(50)]
        public string Porte { get; set; } = null!;
        [StringLength(50)]
        public string? Capital { get; set; }
    }
}
