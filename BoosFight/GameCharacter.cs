using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoosFight
{
    internal class GameCharacter
    {
        public string Name;
        public int HP;
        public int Stamina;
        public int StaminaMax;
        public int Dmg;

        public GameCharacter(string name, int hp, int stamina, int dmg)
        {
            Name = name;
            HP = hp;
            Stamina = stamina;
            Dmg = dmg;
            StaminaMax = stamina;
        }

        public int Attack()
        {
            if (Stamina <= 0) return -1; 
            
            var random = new Random();
            var ran = random.Next(0, Dmg);
           
            var dmgDealt = Name == "Hero" ? Dmg : ran;
            Stamina -= 10;
            return dmgDealt;
        }

        public void Recharge()
        {
            Stamina = StaminaMax;
        }
    }
}