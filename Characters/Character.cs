using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FinalBattle.Enums;
using FinalBattle.Items;

namespace FinalBattle
{
    public class Character
    {
        public string _name { set; get; }
        public int _maxHealth { set; get; }
        public int _currentHealth { set; get; }

        public Gear _gear { set; get; }

        public bool IsCharacterEquipped() => _gear._gearType != GearType.Nothing;
    }  
}
