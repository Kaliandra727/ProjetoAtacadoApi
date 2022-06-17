using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Keyless]
    [Table("RAW_DATA_Cidades_IBGE6_UTF8")]
    public partial class RawDataCidadesIbge6Utf8
    {
        [Column("CIDADE")]
        [Unicode(false)]
        public string Cidade { get; set; } = null!;
        [Column("UF")]
        [StringLength(2)]
        [Unicode(false)]
        public string Uf { get; set; } = null!;
        [Column("CEP")]
        public long Cep { get; set; }
        [Column("IBGE")]
        public long Ibge { get; set; }
    }
}
