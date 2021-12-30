using FinalBattle.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Menus
{
    public record MenuItem(string Description, ActionType action)
    {
        public override string ToString() => $"{Description}";
    }
}
