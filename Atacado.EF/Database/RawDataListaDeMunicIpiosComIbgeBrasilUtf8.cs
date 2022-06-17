using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Keyless]
    [Table("RAW_DATA_Lista_de_MunicIpios_com_IBGE_Brasil_UTF8")]
    public partial class RawDataListaDeMunicIpiosComIbgeBrasilUtf8
    {
        [Column("ConcatUF_Mun")]
        [Unicode(false)]
        public string ConcatUfMun { get; set; } = null!;
        [Column("IBGE")]
        public long Ibge { get; set; }
        [Column("IBGE7")]
        public long Ibge7 { get; set; }
        [Column("UF")]
        [StringLength(2)]
        [Unicode(false)]
        public string Uf { get; set; } = null!;
        [Unicode(false)]
        public string Município { get; set; } = null!;
        [Unicode(false)]
        public string Região { get; set; } = null!;
        [Column("População_2010")]
        public long? População2010 { get; set; }
        [Unicode(false)]
        public string Porte { get; set; } = null!;
        [StringLength(50)]
        public string? Capital { get; set; }
    }
}
