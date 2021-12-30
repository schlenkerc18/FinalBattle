using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Menus;

namespace FinalBattle.Actions
{
    public class DoNothingAction : IAction
    {
        public void DoNothing(Party friends, Party enemies)
        {
            Console.WriteLine($"{friends.characters[0]._name} did nothing.");
        }

        public void ComputerAction(Party friends, Party enemies, ActionType action)
        {
            DoNothing(friends, enemies);
        }

        public void PlayerAction(Party friends, Party enemies, ActionType action)
        {
            DoNothing(friends, enemies);
        }
    }
}
