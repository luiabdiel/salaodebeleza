using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using salaodebeleza.Models;

namespace salaodebeleza.Data {
    public class AppDb : IdentityDbContext {
        public AppDb(DbContextOptions<AppDb> options): base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<Venda>()
        //        .HasOne(venda => venda.Cliente)
        //        .WithMany(cliente => cliente.Vendas)
        //        .IsRequired(true)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    builder.Entity<VendaItem>()
        //        .HasOne(venda => venda.Servico)
        //        .WithMany(produto => produto.Itens)
        //        .IsRequired(true)
        //        .OnDelete(DeleteBehavior.Restrict);
        //}

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<VendaItem> VendasItens { get; set; }
        public DbSet<Venda> Vendas { get; set; }

    }
}