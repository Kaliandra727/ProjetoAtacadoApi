using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Atacado.EF.Database
{
    public partial class AtacadoContext : DbContext
    {
        public AtacadoContext()
        {
        }

        public AtacadoContext(DbContextOptions<AtacadoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AreaConhecimento> AreaConhecimentos { get; set; } = null!;
        public virtual DbSet<Banco> Bancos { get; set; } = null!;
        public virtual DbSet<Carrinho> Carrinhos { get; set; } = null!;
        public virtual DbSet<CarrinhoIten> CarrinhoItens { get; set; } = null!;
        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Distrito> Distritos { get; set; } = null!;
        public virtual DbSet<FormaEnvio> FormaEnvios { get; set; } = null!;
        public virtual DbSet<FormaPagamento> FormaPagamentos { get; set; } = null!;
        public virtual DbSet<FuncionarioDadosEmpresa> FuncionarioDadosEmpresas { get; set; } = null!;
        public virtual DbSet<FuncionarioDadosPessoai> FuncionarioDadosPessoais { get; set; } = null!;
        public virtual DbSet<Idioma> Idiomas { get; set; } = null!;
        public virtual DbSet<Mesoregiao> Mesoregiaos { get; set; } = null!;
        public virtual DbSet<Microregiao> Microregiaos { get; set; } = null!;
        public virtual DbSet<Municipio> Municipios { get; set; } = null!;
        public virtual DbSet<Pai> Pais { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<PrimeiroNome> PrimeiroNomes { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<Profissao> Profissaos { get; set; } = null!;
        public virtual DbSet<RawDataCidadesIbge6Utf8> RawDataCidadesIbge6Utf8s { get; set; } = null!;
        public virtual DbSet<RawDataListaDeMunicIpiosComIbgeBrasilUtf8> RawDataListaDeMunicIpiosComIbgeBrasilUtf8s { get; set; } = null!;
        public virtual DbSet<RawDataMunicipiosComplementarIbgeUtf8> RawDataMunicipiosComplementarIbgeUtf8s { get; set; } = null!;
        public virtual DbSet<SubDistrito> SubDistritos { get; set; } = null!;
        public virtual DbSet<Subcategoria> Subcategorias { get; set; } = null!;
        public virtual DbSet<TipoFormaPagamento> TipoFormaPagamentos { get; set; } = null!;
        public virtual DbSet<TipoLogradouro> TipoLogradouros { get; set; } = null!;
        public virtual DbSet<UnidadeFederacao> UnidadeFederacaos { get; set; } = null!;
        public virtual DbSet<VwFuncionariosAtivosInformacao> VwFuncionariosAtivosInformacaos { get; set; } = null!;
        public virtual DbSet<VwInformacaoProduto> VwInformacaoProdutos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=Atacado202204;User Id=sa;Password=senha123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaConhecimento>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Carrinho>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.Carrinhos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Carrinho");
            });

            modelBuilder.Entity<CarrinhoIten>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdCarrinhoNavigation)
                    .WithMany(p => p.CarrinhoItens)
                    .HasForeignKey(d => d.IdCarrinho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrinho_Carrinho_Itens");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.CarrinhoItens)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produto_Carrinho_Itens");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Categoria>().ToTable("Categoria");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepto)
                    .HasName("PK_Depto");

                entity.Property(e => e.IdDepto).ValueGeneratedNever();

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiglaUf).IsFixedLength();

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SiglaUfNavigation)
                    .WithMany(p => p.Distritos)
                    .HasPrincipalKey(p => p.SiglaUf)
                    .HasForeignKey(d => d.SiglaUf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiglaUF_Distrito");
            });

            modelBuilder.Entity<FormaEnvio>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<FormaPagamento>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdTipoFormaPagamentoNavigation)
                    .WithMany(p => p.FormaPagamentos)
                    .HasForeignKey(d => d.IdTipoFormaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Forma_Pagamento_Tipo_Forma_Pagamento");
            });

            modelBuilder.Entity<FuncionarioDadosEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdFuncDadosEmpresa)
                    .HasName("PK_FuncDadosEmpresa");

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<FuncionarioDadosPessoai>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PK_FuncDadosPessoais");

                entity.Property(e => e.IdFuncionario).ValueGeneratedNever();

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SexoFuncionario).IsFixedLength();

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.Property(e => e.AbreviacaoIdioma).IsFixedLength();

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Mesoregiao>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiglaUf).IsFixedLength();

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SiglaUfNavigation)
                    .WithMany(p => p.Mesoregiaos)
                    .HasPrincipalKey(p => p.SiglaUf)
                    .HasForeignKey(d => d.SiglaUf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiglaUF_Mesoregiao");
            });

            modelBuilder.Entity<Microregiao>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiglaUf).IsFixedLength();

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SiglaUfNavigation)
                    .WithMany(p => p.Microregiaos)
                    .HasPrincipalKey(p => p.SiglaUf)
                    .HasForeignKey(d => d.SiglaUf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiglaUF_Microregiao");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiglaUf).IsFixedLength();

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdMesoregiaoNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdMesoregiao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mesoregiao_Municipio");

                entity.HasOne(d => d.IdMicroregiaoNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdMicroregiao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Microregiao_Municipio");

                entity.HasOne(d => d.IdUnidadeFederacaoNavigation)
                    .WithMany(p => p.MunicipioIdUnidadeFederacaoNavigations)
                    .HasForeignKey(d => d.IdUnidadeFederacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unidade_Federacao_Municipio");

                entity.HasOne(d => d.SiglaUfNavigation)
                    .WithMany(p => p.MunicipioSiglaUfNavigations)
                    .HasPrincipalKey(p => p.SiglaUf)
                    .HasForeignKey(d => d.SiglaUf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiglaUF_Municipio");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.Property(e => e.AbreviacaoIdioma).IsFixedLength();

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiglaPais).IsFixedLength();

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Pedido");

                entity.HasOne(d => d.IdFormaEnvioNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdFormaEnvio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Forma_Envio_Pedido");

                entity.HasOne(d => d.IdFormaPagamentoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdFormaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagamento_Pedido_Forma");
            });

            modelBuilder.Entity<PrimeiroNome>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SexoPrimeiroNome).IsFixedLength();

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdSubcategoriaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdSubcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subcategoria_Produto");
            });

            modelBuilder.Entity<Profissao>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<RawDataCidadesIbge6Utf8>(entity =>
            {
                entity.Property(e => e.Uf).IsFixedLength();
            });

            modelBuilder.Entity<RawDataListaDeMunicIpiosComIbgeBrasilUtf8>(entity =>
            {
                entity.Property(e => e.Uf).IsFixedLength();
            });

            modelBuilder.Entity<RawDataMunicipiosComplementarIbgeUtf8>(entity =>
            {
                entity.Property(e => e.MunicipioId).ValueGeneratedNever();
            });

            modelBuilder.Entity<SubDistrito>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiglaUf).IsFixedLength();

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SiglaUfNavigation)
                    .WithMany(p => p.SubDistritos)
                    .HasPrincipalKey(p => p.SiglaUf)
                    .HasForeignKey(d => d.SiglaUf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiglaUF_SubDistrito");
            });

            modelBuilder.Entity<Subcategoria>(entity =>
            {
                entity.Property(e => e.Datainsert).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Subcategoria)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subcategoria_Categoria");
            });

            modelBuilder.Entity<Subcategoria>().ToTable("Subcategoria");

            modelBuilder.Entity<TipoFormaPagamento>(entity =>
            {
                entity.Property(e => e.IdTipoFormaPagamento).ValueGeneratedNever();

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TipoLogradouro>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<UnidadeFederacao>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiglaUf).IsFixedLength();

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<VwFuncionariosAtivosInformacao>(entity =>
            {
                entity.ToView("VW_Funcionarios_Ativos_Informacao");

                entity.Property(e => e.SexoFuncionario).IsFixedLength();
            });

            modelBuilder.Entity<VwInformacaoProduto>(entity =>
            {
                entity.ToView("VW_Informacao_Produto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
