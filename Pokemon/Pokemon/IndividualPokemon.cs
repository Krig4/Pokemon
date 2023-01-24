using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class IndividualPokemon // Stats sacadas de https://veekun.com/
    {
        SpeciesPokemon specie;
        char gender;
        string eo;
        DateTime? catDate;
        Moves[] movement;
        public IndividualPokemon(SpeciesPokemon specie)
        {
            this.specie = specie;
            this.gender = GenerateGender();
            this.movement = new Moves[4];
        }
        public int GenerateCatchRate()
        {
            Random random = new Random();
            int catchRate = random.Next(0, 256);
            return catchRate;
        }
        public char GenerateGender() // Generador automático de genero del Pokemon
        {
            Random random = new Random();
            int sex = random.Next(0, 2);
            if (sex == 0)
            {
                gender = '♂';
            }
            else if (sex == 1)
            {
                gender = '♀';
            }
            return gender;
        }
        public DateTime? GetDate() // Se crean los Get y Set para todos los atributos 
        {
            return catDate;
        }
        public void SetDate(DateTime? date)
        {
            this.catDate = date;
        }
        public char GetGender()
        {
            return gender;
        }
        public string GetEO()
        {
            return eo;
        }
        public void SetEO(string eo)
        {
            this.eo = eo;
        }
        public void SetName(string name)
        {
            specie.SetName(name);
        }
        public string GetName()
        {
            return specie.GetName();
        }
        public void SetType(string type)
        {
            specie.SetType(type);
        }
        public string getType()
        {
            return specie.getType();
        }
        public void SetId(int id)
        {
            specie.SetId(id);
        }
        public int GetId()
        {
            return specie.GetId();
        }
        public void SetLevel(int level)
        {
            specie.SetLevel(level);
        }
        public int GetLevel()
        {
            return specie.GetLevel();
        }
        public void SetHp(int hp)
        {
            specie.SetHp(hp);
        }
        public int GetHp()
        {
            return specie.GetHp();
        }
        public void SetAtk(int atk)
        {
            specie.SetAtk(atk);
        }
        public int GetAtk()
        {
            return specie.GetAtk();
        }
        public void SetDef(int def)
        {
            specie.SetDef(def);
        }
        public int GetDef()
        {
            return specie.GetDef();
        }
        public void SetSpDef(int spDef)
        {
            specie.SetSpDef(spDef);
        }
        public int GetSpDef()
        {
            return specie.GetSpDef();
        }
        public void SetSpAtk(int spAtk)
        {
            specie.SetSpAtk(spAtk);
        }
        public int GetSpAtk()
        {
            return specie.GetSpAtk();
        }
        public void SetSpeed(int speed)
        {
            specie.SetSpeed(speed);
        }
        public int GetSpeed()
        {
            return specie.GetSpAtk();
        }
        public void SetMaxHP(int maxHP)
        {
            specie.SetMaxHP(maxHP);
        }
        public int GetMaxHP()
        {
            return specie.GetMaxHP();
        }
        public Moves[] GetMoves()
        {
            Random random = new Random();
            int mov = random.Next(0, movement.Length);
            return movement;
        }
    }
}
