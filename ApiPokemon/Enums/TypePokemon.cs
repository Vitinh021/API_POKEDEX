using System.ComponentModel;

namespace ApiPokemon.Enums
{
    public enum TypePokemon
    {
        [Description("Fogo")]
        Fire = 0,
        [Description("Agua")]
        Water = 1,
        [Description("Terra")]
        Ground = 2,
        [Description("Ar")]
        Air = 3    
    }
}
