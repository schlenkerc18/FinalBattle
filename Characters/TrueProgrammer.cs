using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Enums;
using FinalBattle.Items;

namespace FinalBattle.Characters
{
    public class TrueProgrammer : Character
    {
        public TrueProgrammer(string name, GearType gearType)
        {
            _maxHealth = 25;
            _currentHealth = 25;
            _name = name;
            _gear = new Gear(GearType.Sword);
            _characterType = CharacterType.TrueProgrammer;
        }
    }
}
