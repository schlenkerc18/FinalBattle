using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Actions
{
    public class AttackAction : IAction
    {
        public AttackType PunchAttack(Party friends, Party enemies)
        {
            Console.WriteLine($"{friends.characters[0]._name} used Punch on {enemies.characters[0]._name}.");
            return AttackType.Punch;
        }

        public AttackType UnravelingAttack(Party friends, Party enemies)
        {
            Console.WriteLine($"{friends.characters[0]._name} used Unraveling on {enemies.characters[0]._name}.");
            return AttackType.Unraveling;
        }

        public AttackType BoneCrunchAttack(Party friends, Party enemies)
        {
            Console.WriteLine($"{friends.characters[0]._name} used Bone Crunch on {enemies.characters[0]._name}.");
            return AttackType.BoneCrunch;
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
