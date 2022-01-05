using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Enums;
using FinalBattle.Items;

namespace FinalBattle.Characters
{
    public class HeroCompanion : Character
    {
        public HeroCompanion(string name, GearType gearType)
        {
            _name = name;
            _currentHealth = 10;
            _maxHealth = 10;
            _gear = new Gear(gearType);
        }
    }
}
