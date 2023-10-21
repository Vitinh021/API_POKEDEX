using ApiPokemon.Data;
using ApiPokemon.Models;
using ApiPokemon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemon.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DBContex _dbContex;

        public PokemonRepository(DBContex DbContex)
        { 
            _dbContex = DbContex;
        }

        public async Task<List<Pokemon>> GetAllPokemons()
        {
            return await _dbContex.Pokemons.ToListAsync();
        }

        public async Task<Pokemon> GetByIdPokemon(int id)
        {
            return await _dbContex.Pokemons.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pokemon> SavePokemon(Pokemon pokemon)
        {
            await _dbContex.Pokemons.AddAsync(pokemon);
            await _dbContex.SaveChangesAsync();
            return pokemon;
        }

        public async Task<Pokemon> UpdatePokemon(Pokemon pokemon, int id)
        {
            Pokemon pokemonOpt = await GetByIdPokemon(id);

            if (pokemonOpt != null)
            {
                pokemonOpt.Name = pokemon.Name;
                pokemonOpt.Description = pokemon.Description;
                pokemonOpt.Type = pokemon.Type;

                _dbContex.Pokemons.Update(pokemonOpt);
                await _dbContex.SaveChangesAsync();
                return pokemonOpt;
            }
            else
            {
                throw new Exception("Pokemon não encontrado!");
            }
        }

        public async Task<bool> DeletePokemon(int id)
        {
            Pokemon pokemonOpt = await GetByIdPokemon(id);

            if (pokemonOpt != null)
            {
                _dbContex.Pokemons.Remove(pokemonOpt);
                await _dbContex.SaveChangesAsync();
                return true;
            }
            else 
            {
                throw new Exception("Pokemon não encontrado!");
            }

        }
    }
}
