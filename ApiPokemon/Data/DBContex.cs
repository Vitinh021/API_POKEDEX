using ApiPokemon.Data.Map;
using ApiPokemon.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemon.Data
{
    public class DBContex : DbContext
    {
        public DBContex(DbContextOptions<DBContex> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PokemonMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
