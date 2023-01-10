using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class IndividualPokemon // Stats sacadas de https://veekun.com/
    {        
        public static SpeciesPokemon[] InitPokemons() // Pokemons iniciales
        {
            SpeciesPokemon[] initPokemons = new SpeciesPokemon[3];            
            initPokemons[0] = new SpeciesPokemon("Bulbasaur", "Planta", 001, 5, 45, 49, 49, 65, 65, 45, 45);
            initPokemons[1] = new SpeciesPokemon("Squirtle", "Agua", 007, 5, 44, 48, 65, 50, 64, 43, 44); 
            initPokemons[2] = new SpeciesPokemon("Charmander", "Fuego", 004, 5, 39, 52, 43, 60, 50, 65, 39); 
            return initPokemons;
        }
        public static SpeciesPokemon[] EnemyPokemons() // Pokemons enemigos 
        {
            SpeciesPokemon[] enemyPokemons = new SpeciesPokemon[151];
            enemyPokemons[0] = new SpeciesPokemon("Pidgey", "Volador", 016, 5, 40, 45, 40, 35, 35, 56, 40);
            enemyPokemons[1] = new SpeciesPokemon("Caterpie", "Bicho", 010, 5, 45, 30, 35, 20, 20, 45, 45);
            enemyPokemons[2] = new SpeciesPokemon("Rattata", "Normal", 019, 5, 30, 56, 35, 25, 35, 72, 30);
            enemyPokemons[3] = new SpeciesPokemon("Bulbasaur", "Planta", 001, 5, 45, 49, 49, 65, 65, 45, 45);
            enemyPokemons[4] = new SpeciesPokemon("Squirtle", "Agua", 007, 5, 44, 48, 65, 50, 64, 43, 44);
            enemyPokemons[5] = new SpeciesPokemon("Charmander", "Fuego", 004, 5, 39, 52, 43, 60, 50, 65, 39);
            return enemyPokemons;
        }
        public static SpeciesPokemon[] MyPokemons() // Mis Pokémons
        {
            SpeciesPokemon[] myPokemons = new SpeciesPokemon[6];
            return myPokemons;
        }        
    }
}
