using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Enums;
using FinalBattle.Items;

namespace FinalBattle.Characters
{
    public class StoneAmarok : Character
    {
        public StoneAmarok(GearType gearType)
        {
            _name = "Stone Amarok";
            _currentHealth = 4;
            _maxHealth = 4;
            _gear = new Gear(gearType);
            _characterType = CharacterType.StoneAmarok;
        }
    }
}
