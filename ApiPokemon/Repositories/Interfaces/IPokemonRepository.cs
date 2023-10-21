using ApiPokemon.Models;

namespace ApiPokemon.Repositories.Interfaces
{
    public interface IPokemonRepository
    {
        Task<List<Pokemon>> GetAllPokemons();
        Task<Pokemon> GetByIdPokemon(int id);
        Task<Pokemon> SavePokemon(Pokemon pokemon);
        Task<Pokemon> UpdatePokemon(Pokemon pokemon, int id);
        Task<bool> DeletePokemon(int id);

    }
}
