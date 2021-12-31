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
        public void ComputerAction(Party friends, Party enemies, ActionType action, Character attackingCharacter)
        {
            Attack(friends, enemies, action, attackingCharacter);
        }

        public void HumanAction(Party friends, Party enemies, ActionType action, Character attackingCharacter)
        {
            Attack(friends, enemies, action, attackingCharacter);
        }

        public void Attack(Party friends, Party enemies, ActionType action, Character attackingCharacter)
        {
            int characterPosition = ChooseCharacterToAttack(friends, enemies);
            Console.WriteLine($"{attackingCharacter._name} used {action} on {enemies.characters[characterPosition]._name}.");
            DealHitDamage(attackingCharacter, enemies, action, characterPosition);
        }

        public int ChooseCharacterToAttack(Party friends, Party enemies)
        {
            // if there is only one enemy character, just return 0 to save tie
            if (enemies.characters.Count == 1) return 0;

            Console.WriteLine("Choose an enemy to attack");

            for (int i = 0; i < enemies.characters.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {enemies.characters[i]._name}");
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            // need to subtract one from choice because characters is 0 indexed
            return choice - 1;

        }

        public void DealHitDamage(Character attackingCharacter, Party enemies, ActionType action, int characterPosition)
        {
            int hitDamage = 0;
            Random random = new Random();

            hitDamage = action switch
            {
                ActionType.BoneCrunch => random.Next(2),
                ActionType.Unraveling => random.Next(3),
                ActionType.Punch => 1
            };

            if (enemies.characters[characterPosition]._currentHealth - hitDamage <= 0)
            {
                enemies.characters[characterPosition]._currentHealth = 0;
            }
            else enemies.characters[characterPosition]._currentHealth -= hitDamage;

            Console.WriteLine($"The attack dealt {hitDamage} damage to {enemies.characters[characterPosition]._name}.");

            Console.WriteLine($"{enemies.characters[characterPosition]._name} is now at " +
                $"{enemies.characters[characterPosition]._currentHealth}/{enemies.characters[characterPosition]._maxHealth}");

            if (enemies.characters[characterPosition]._currentHealth == 0) 
                RemoveCharacterFromParty(attackingCharacter, enemies, characterPosition);
        }

        public void RemoveCharacterFromParty(Character attackingCharacter, Party enemies, int characterPosition)
        {
            Console.WriteLine($"{attackingCharacter._name} killed {enemies.characters[characterPosition]._name}");
            enemies.characters.Remove(enemies.characters[characterPosition]);
            Console.WriteLine();
        }
    }
}
