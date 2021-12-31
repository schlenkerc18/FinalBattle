using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Characters
{
    public class Skeleton : Character
    {
        public Skeleton(string name)
        {
            _maxHealth = 5;
            _currentHealth = 5;
            _name = name;
        }
    }
}
