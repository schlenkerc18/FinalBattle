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
        public void ComputerAction(Party friends, Party enemies, ActionType action, Character character)
        {
            if (action == ActionType.Punch) PunchAttack(friends, enemies);
            else if (action == ActionType.Unraveling) UnravelingAttack(friends, enemies);
            else BoneCrunchAttack(friends, enemies);
        }

        public void HumanAction(Party friends, Party enemies, ActionType action, Character character)
        {
            if (action == ActionType.Punch) PunchAttack(friends, enemies);
            else if (action == ActionType.Unraveling) UnravelingAttack(friends, enemies);
            else BoneCrunchAttack(friends, enemies);
        }

        public void PunchAttack(Party friends, Party enemies)
        {
            Console.WriteLine($"{friends.characters[0]._name} used Punch on {enemies.characters[0]._name}.");
            DealHitDamage(friends, enemies, ActionType.Punch);
        }

        public void UnravelingAttack(Party friends, Party enemies)
        {
            Console.WriteLine($"{friends.characters[0]._name} used Unraveling on {enemies.characters[0]._name}.");
            DealHitDamage(friends, enemies, ActionType.Unraveling);
        }

        public void BoneCrunchAttack(Party friends, Party enemies)
        {
            Console.WriteLine($"{friends.characters[0]._name} used Bone Crunch on {enemies.characters[0]._name}.");
            DealHitDamage(friends, enemies, ActionType.BoneCrunch);
        }

        public void DealHitDamage(Party friends, Party enemies, ActionType action)
        {
            int hitDamage = 0;
            Random random = new Random();

            hitDamage = action switch
            {
                ActionType.BoneCrunch => random.Next(2),
                ActionType.Unraveling => random.Next(3),
                ActionType.Punch => 1
            };

            if (enemies.characters[0]._currentHealth - hitDamage <= 0)
            {
                enemies.characters[0]._currentHealth = 0;
            }
            else enemies.characters[0]._currentHealth -= hitDamage;

            Console.WriteLine($"The attack dealt {hitDamage} damage to {enemies.characters[0]._name}.");
            Console.WriteLine($"{enemies.characters[0]._name} is now at {enemies.characters[0]._currentHealth}/{enemies.characters[0]._maxHealth}");

            if (enemies.characters[0]._currentHealth == 0) RemoveCharacterFromParty(friends, enemies, enemies.characters[0]);
        }

        public void RemoveCharacterFromParty(Party friends, Party enemies, Character character)
        {
            enemies.characters.Remove(character);
            Console.WriteLine();
            Console.WriteLine($"{friends.characters[0]._name} killed {character._name}");
        }
    }
}
