using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Enums;
using FinalBattle.Items;

namespace FinalBattle.Characters
{
    public class Skeleton : Character
    {
        public Skeleton(string name)
        {
            _maxHealth = 5;
            _currentHealth = 5;
            _name = name;
            _gear = new Gear(GearType.Nothing);
        }
    }
}
