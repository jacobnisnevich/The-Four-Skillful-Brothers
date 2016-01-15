using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class Character
    {
        public string Name { get; set; }

        // Basic Stats
        public int Health { get; set; }
        public int Energy { get; set; }
        public int Damage { get; set; }
        public int Movement { get; set; }
        public int Range { get; set; }

        // Advanced Stats
        public int DodgeChance { get; set; }
        public int HitChance { get; set; }

        public Character(string name, int health, int energy, int damage, int movement, int range, int dodgeChance, int hitChance)
        {
            Name = name;
            Health = health;
            Energy = energy;
            Damage = damage;
            Movement = movement;
            Range = range;
            DodgeChance = dodgeChance;
            HitChance = hitChance;
        }

        public bool rollDodge() {
            Random rand = new Random();
            int randDecimal = rand.Next(100);

            if (randDecimal > DodgeChance * 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool rollHit()
        {
            Random rand = new Random();
            int randDecimal = rand.Next(100);

            if (randDecimal > HitChance * 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
