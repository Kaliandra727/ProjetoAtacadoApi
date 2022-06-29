﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.EF.Database
{
    [Table("EMPRESA")]

    public partial class Empresa
    {
        [Key]
        [Column("ID_EMPRESA")]
        public int IdEmpresa { get; set; }

        [Column("RAZAOSOCIAL")]
        [Unicode(false)]
        public string RazaoSocial { get; set; }

        [Column("NOMEFANTASIA")]
        [Unicode(false)]
        public string NomeFantasia { get; set; }

        [Column("CNPJ")]
        [StringLength(14)]
        [Unicode(false)]
        public string CNPJ { get; set; }

        [Column("INSCRICAOESTADUAL")]
        [StringLength(9)]
        [Unicode(false)]
        public string InscricaoEstadual { get; set; }

        [Column("TELEFONE")]
        [StringLength(20)]
        [Unicode(false)]
        public string Telefone { get; set; }

        [Column("EMAIL")]
        [Unicode(false)]
        public string Email { get; set; }

        [Column("ENDERECO")]
        [Unicode(false)]
        public string Endereco { get; set; }
    }
}
