using ApiPokemon.Enums;

namespace ApiPokemon.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TypePokemon Type { get; set;}
    }
}
