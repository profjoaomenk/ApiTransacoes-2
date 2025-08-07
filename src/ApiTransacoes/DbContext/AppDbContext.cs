using Microsoft.EntityFrameworkCore;
using ApiTransacoes.Models;

namespace ApiTransacoes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Transacao> Transacoes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.ToTable("transacoes");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Descricao).HasColumnName("descricao");
                entity.Property(e => e.Valor).HasColumnName("valor");
                entity.Property(e => e.DataTransacao).HasColumnName("data_transacao")
                      .HasColumnName("data_transacao")
                      .HasColumnName("data_transacao")
                      .ValueGeneratedOnAdd();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
