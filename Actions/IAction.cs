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
        void DecidePlayerAction(Party friends, Party enemies, ActionType action, PlayerType playerType, Character character)
        {
            if (playerType == PlayerType.Computer) ComputerAction(friends, enemies, action, character);
            else HumanAction(friends, enemies, action, character);
        }

        void HumanAction(Party friends, Party enemies, ActionType action, Character character);

        void ComputerAction(Party friends, Party enemies, ActionType action, Character character);
    }
}
