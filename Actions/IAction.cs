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
        void DecidePlayerAction(Party friends, Party enemies, ActionType action, PlayerType playerType)
        {
            if (playerType == PlayerType.Computer) ComputerAction(friends, enemies, action);
            else HumanAction(friends, enemies, action);
        }

        void HumanAction(Party friends, Party enemies, ActionType action);

        void ComputerAction(Party friends, Party enemies, ActionType action);
    }
}
