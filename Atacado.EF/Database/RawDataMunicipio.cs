using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Keyless]
    [Table("RAW_DATA_Municipio")]
    public partial class RawDataMunicipio
    {
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
        [StringLength(2)]
        [Unicode(false)]
        public string Ufid { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime DataInsert { get; set; }
    }
}
