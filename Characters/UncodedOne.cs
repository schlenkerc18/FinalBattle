using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Items;
using FinalBattle.Enums;

namespace FinalBattle.Characters
{
    class UncodedOne : Character
    {
        public UncodedOne()
        {
            _maxHealth = 15;
            _currentHealth = 15;
            _name = "The Uncoded One";
            _gear = new Gear(GearType.Nothing);
            _characterType = CharacterType.UncodedOne;
        }
    }
}
