using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Enums;

namespace FinalBattle.Items
{
    public class Gear
    {
        public GearType _gearType { get; private set; }

        public Gear(GearType gearType)
        {
            _gearType = gearType;
        }
    }
}
