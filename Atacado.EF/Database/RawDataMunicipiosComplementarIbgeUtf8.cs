using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("RAW_DATA_Municipios_Complementar_IBGE_UTF8")]
    public partial class RawDataMunicipiosComplementarIbgeUtf8
    {
        [Key]
        [Column("MunicipioID")]
        public int MunicipioId { get; set; }
        [Column("CodigoIBGE")]
        public long CodigoIbge { get; set; }
        [Unicode(false)]
        public string Nome { get; set; } = null!;
        [Column("MesoregiaoID")]
        public int MesoregiaoId { get; set; }
        [Column("MicroregiaoID")]
        public int MicroregiaoId { get; set; }
        [Column("UFID")]
        public int Ufid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataInsert { get; set; }
    }
}
