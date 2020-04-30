using Microsoft.EntityFrameworkCore;
using Pizza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.DbContexts
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) { }

        public DbSet<Adresses> Adresses { get; set; }
        public DbSet<BonLiv> BonLiv { get; set; }
        public DbSet<Catalogue_Pizza> Catalogue_Pizza { get; set; }
        public DbSet<CdeCli> CdeCli { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Detail_Liv> Detail_Liv { get; set; }
        public DbSet<Fabrication> Fabrication { get; set; }
        public DbSet<Fact_Cli_BonLiv> Fact_Cli_BonLiv { get; set; }
        public DbSet<Ligne_Cde_Cli> Ligne_Cde_Cli { get; set; }
        public DbSet<Livraison> Livraison { get; set; }
        public DbSet<Livreur> Livreur { get; set; }
        public DbSet<Paiement_Cli> Paiement_Cli { get; set; }
        public DbSet<Num_Cde_Cli> Quartier { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Livreur>().HasIndex(e => e.Num_Quartier).IsUnique();

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    } 
}
