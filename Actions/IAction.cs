using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Menus;

namespace FinalBattle.Actions
{
    public interface IAction
    {
        void PlayerAction(Party friends, Party enemies, ActionType action);

        void ComputerAction(Party friends, Party enemies, ActionType action);
    }
}
