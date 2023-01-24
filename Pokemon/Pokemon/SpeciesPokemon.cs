using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class SpeciesPokemon // Atributos que tendrá el Pokemon
    {
        string name;        
        string type;        
        int id;
        int level;
        int hp;
        int atk;
        int def;
        int spAtk;
        int spDef;
        int speed;
        int maxHP;              
        public SpeciesPokemon(string name, string type, int id, int level, int hp, int atk, int def, int spAtk, int spDef, int speed, int maxHP) // Constructor para los atributos
        {
            this.name = name;
            this.type = type;
            this.id = id;            
            this.level = level;
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            this.spAtk = spAtk;
            this.spDef = spDef;
            this.speed = speed;
            this.maxHP = maxHP;                       
        }
        public SpeciesPokemon(int hp) // Constructor para la vida del Pokémon
        {
            this.hp = hp;
        }
        public SpeciesPokemon() // Constructor sin parametros
        { 
        }
        // Se crean los Get y Set para todos los atributos        
        public int GetId()
        {
            return id;
        }
        public void SetId(int id)
        {
            this.id= id;
        }        
        public int GetLevel()
        {
            return level;
        }
        public void SetLevel(int level)
        {
            this.level = level;
        }
        public int GetHp()
        {
            return hp;
        }
        public void SetHp(int hp)
        {
            this.hp = hp;
        }
        public int GetAtk()
        {
            return atk;
        }
        public void SetAtk(int atk)
        {
            this.atk = atk;
        }
        public int GetDef()
        {
            return def;
        }
        public void SetDef(int def)
        {
            this.def = def;
        }
        public int GetSpAtk()
        {
            return spAtk;
        }
        public void SetSpAtk(int spAtk)
        {
            this.spAtk = spAtk;
        }
        public int GetSpDef()
        {
            return spDef;
        }
        public void SetSpDef(int spDef)
        {
            this.spDef = spDef;
        }
        public int GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }
        public int GetMaxHP()
        {
            return maxHP;
        }
        public void SetMaxHP(int maxHP)
        {
            this.maxHP = maxHP;
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string getType() // Se pone G en minuscula porque GetType es una función reservada de C# 
        {
            return type;
        }
        public void SetType(string type)
        {
            this.type = type;
        }        
    }
}
