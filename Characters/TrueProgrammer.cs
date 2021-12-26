using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Characters
{
    public class TrueProgrammer : Character
    {
        public TrueProgrammer(string name)
        {
            _maxHealth = 25;
            _currentHealth = 25;
            _name = name;
        }
    }
}
