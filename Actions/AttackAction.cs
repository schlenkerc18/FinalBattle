using FinalBattle.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Actions
{
    public class AttackAction : IAction
    {
        public void PunchAttack(Party friends, Party enemies)
        {
            Console.WriteLine($"{friends.characters[0]._name} used Punch on {enemies.characters[0]._name}.");
            friends.characters[0].DealHitDamage(friends, enemies, ActionType.Punch);
            //return AttackType.Punch;
        }

        public void UnravelingAttack(Party friends, Party enemies)
        {
            Console.WriteLine($"{friends.characters[0]._name} used Unraveling on {enemies.characters[0]._name}.");
            friends.characters[0].DealHitDamage(friends, enemies, ActionType.Unraveling);
        }

        public void BoneCrunchAttack(Party friends, Party enemies)
        {
            Console.WriteLine($"{friends.characters[0]._name} used Bone Crunch on {enemies.characters[0]._name}.");
            friends.characters[0].DealHitDamage(friends, enemies, ActionType.BoneCrunch);
        }

        public ActionType ComputerAction(Party friends, Party enemies)
        {
            throw new NotImplementedException();
        }

        public void PlayerAction(Party friends, Party enemies, ActionType action)
        {
            if (action == ActionType.Punch) PunchAttack(friends, enemies);
            else if (action == ActionType.Unraveling) UnravelingAttack(friends, enemies);
            else BoneCrunchAttack(friends, enemies);
        }
    }
}
