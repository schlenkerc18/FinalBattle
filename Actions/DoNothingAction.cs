using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Actions
{
    public class DoNothingAction : IAction
    {
        public ActionType DoNothing(Party friends, Party enemies)
        {
            Console.WriteLine($"{friends.characters[0]._name} did nothing.");

            return ActionType.DoNothing;
        }

        public ActionType ComputerAction(Party friends, Party enemies)
        {
            throw new NotImplementedException();
        }

        public ActionType PlayerAction(Party friends, Party enemies)
        {
            throw new NotImplementedException();
        }
    }
}
