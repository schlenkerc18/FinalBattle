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
        public void ComputerAction(Party friends, Party enemies, ActionType action, Character character)
        {
            DoNothing(friends, enemies);
        }

        public void HumanAction(Party friends, Party enemies, ActionType action, Character character)
        {
            DoNothing(friends, enemies);
        }
        public void DoNothing(Party friends, Party enemies)
        {
            Console.WriteLine($"{friends.characters[0]._name} did nothing.");
        }
    }
}
