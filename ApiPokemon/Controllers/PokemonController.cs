using ApiPokemon.Models;
using ApiPokemon.Repositories;
using ApiPokemon.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> GetAllPokemons()
        {
            List<Pokemon> pokemons = await _pokemonRepository.GetAllPokemons();
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Pokemon>>> GetbyIdPokemom(int id)
        {
            Pokemon pokemon = await _pokemonRepository.GetByIdPokemon(id);
            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<ActionResult<Pokemon>> SavePokemom([FromBody] Pokemon pokemonReq)
        {
            Pokemon pokemonRes = await _pokemonRepository.SavePokemon(pokemonReq);
            return Ok(pokemonRes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pokemon>> UpdatePokemom([FromBody] Pokemon pokemonReq, int id)
        {

            Pokemon pokemonRes = await _pokemonRepository.UpdatePokemon(pokemonReq, id);
            return Ok(pokemonRes);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePokemon(int id)
        {
            bool res = await _pokemonRepository.DeletePokemon(id);
            return Ok(res);
        }
    }
}
