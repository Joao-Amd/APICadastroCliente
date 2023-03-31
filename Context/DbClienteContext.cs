using CadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CadastroCliente.Data
{
    public partial class DbClienteContext : DbContext
    {
        public DbClienteContext()
        {
        }

        public DbClienteContext(DbContextOptions<DbClienteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Pooling=true;Database=DB_Cliente;User Id=postgres;Password=3005;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCliente)
                    .HasName("clientes_pkey");

                entity.ToTable("clientes");

                entity.HasIndex(e => e.CnpjCliente, "clientes_cnpj_cliente_key")
                    .IsUnique();

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.CnpjCliente)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("cnpj_cliente");

                entity.Property(e => e.DataCadastroCliente)
                    .HasColumnType("date")
                    .HasColumnName("data_cadastro_cliente");

                entity.Property(e => e.EnderecoCliente)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("endereco_cliente");

                entity.Property(e => e.NomeCliente)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nome_cliente");

                entity.Property(e => e.TelefoneCliente)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("telefone_cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
