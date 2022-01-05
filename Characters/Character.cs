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
        public string _name { get; set; }
        public int _maxHealth { get; set; }
        public int _currentHealth { get; set; }

        public Gear _gear { get; set; }

        public CharacterType _characterType { get; set; }

        public bool IsCharacterEquipped() => _gear._gearType != GearType.Nothing;
    }  
}
