using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Trainer // Atributos del entrenador
    {
        string name;
        string gender;
        string id;
        int secretID;
        int pokedolar;
        int battlepoint;
        int pokemilles;
        DateTime? createDate;

        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetGender()
        {
            return gender;
        }
        public void SetGender(string gender)
        {
            this.gender = gender;
        }
        public string GenerateGender(int sex)
        {
            if (sex == 1)
            {
                gender = "♂";
            }
            else if (sex == 2)
            {
                gender = "♀";
            }
            else if (sex == 3)
            {
                gender = "♂♀";
            }            
            return gender;
        }
        public string GetId()
        {
            return id;
        }
        public void SetId(string id)
        {
            this.id = id;
        }
        public int GetPokedolar()
        {
            return pokedolar;
        }
        public void SetPokedolar(int pokedolar)
        {
            this.pokedolar = pokedolar;
        }
        public int GetBattlepoint()
        {
            return battlepoint;
        }
        public void SetBattlepoint(int battlepoint)
        {
            this.battlepoint = battlepoint;
        }
        public int GetPokemilles()
        {
            return pokemilles;
        }
        public void SetPokemilles(int pokemilles)
        {
            this.pokemilles = pokemilles;
        }
        public DateTime? GetCreateDate()
        {
            return createDate;
        }
        public void SetCreateDate(DateTime? createDate)
        {
            this.createDate = createDate;
        }
        public void SetSecretID(int secretID)
        {
            this.secretID = secretID;
        }
        public int GetSecretID()
        {
            return secretID;
        }
        public string GenerateMyID()
        {
            Random random = new Random();
            int idregion = random.Next(0, 5);
            Random random1 = new Random();
            int idsecret = random1.Next(000000000, 1000000000);
            string ID = string.Concat(idregion, idsecret);
            return ID;
        }
        public Trainer(string name, string gender, string id, int pokedolar, int battlepoint, int pokemilles)
        {
            this.name = name;
            this.gender = gender;
            this.id = GenerateMyID();
            this.pokedolar = pokedolar;
            this.battlepoint = battlepoint;
            this.pokemilles = pokemilles;            
        }
        public Trainer() // Constructor sin parametros
        {
        }

        public IndividualPokemon[] MyPokemons() // Mis Pokémons
        {
            IndividualPokemon[] myPokemons = new IndividualPokemon[6];
            return myPokemons;
        }
        public IndividualPokemon[][] Boxes() // Cajas Pokémons
        {
            IndividualPokemon[][] array = new IndividualPokemon[32][];
            for(int i = 0; i < array.Length; ++i)
            {
                array[i] = new IndividualPokemon[30];
            }
            return array;
        }
    }    
}
