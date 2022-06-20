using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Keyless]
    [Table("RAW_DATA_Cidade")]
    public partial class RawDataCidade
    {
        [Column("CIDADE")]
        [Unicode(false)]
        public string Cidade { get; set; } = null!;
        [Column("UF")]
        [StringLength(2)]
        [Unicode(false)]
        public string Uf { get; set; } = null!;
        [Column("CEP")]
        public int Cep { get; set; }
        [Column("IBGE")]
        public long Ibge { get; set; }
    }
}
