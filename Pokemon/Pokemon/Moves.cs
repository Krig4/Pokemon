using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Moves // Atributos que tendrá los movimientos
    {
        string name;
        int pp;
        int power;
        int precision;
        int priority;
        string category;

        public Moves(string category, string name, int power, int pp, int precision, int priority) // Constructor para los atributos
        {
            this.name = name;
            this.pp = pp;
            this.power = power;
            this.precision = precision;
            this.priority = priority;
            this.category = category;
        }
        public Moves() // Constructor vacio
        {
        }
        public string GetName() // Se crean los Get y Set para todos los atributos 
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public int GetPp()
        {
            return pp;
        }
        public void SetPp(int pp)
        {
            this.pp = pp;
        }
        public int GetPower()
        {
            return power;
        }
        public void SetPower(int power)
        {
            this.power = power;
        }
        public int GetPrecision()
        {
            return precision;
        }
        public void SetPrecision(int precision)
        {
            this.precision = precision;
        }
        public int GetPriority()
        {
            return priority;
        }
        public void SetPriority(int priority)
        {
            this.priority = priority;
        }
        public string GetCategory()
        {
            return category;
        }
        public void SetCategory(string category)
        {
            this.category = category;
        }
    }
}
