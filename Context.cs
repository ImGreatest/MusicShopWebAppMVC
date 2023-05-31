using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using MusicShopWebAppMVC.Models;

//MusicShopWebAppMVCStore
namespace MusicShopWebAppMVC
{

    public class ContextDB : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=musicstreamingservice; Username=postgres; Password=889988");
        }
        
        public ContextDB()
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Album> Album { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Condition> Condition { get; set; }
        public DbSet<Label> Label { get; set; }
        public DbSet<Performer> Performer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Style> Style { get; set; }
        public DbSet<TypeProduct> TypeProduct { get; set; }
    }
    
}