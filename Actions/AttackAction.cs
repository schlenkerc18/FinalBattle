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
            int characterPosition = ChooseCharacterToAttack(friends, enemies);
            Console.WriteLine($"{friends.characters[0]._name} used Punch on {enemies.characters[characterPosition]._name}.");
            DealHitDamage(friends, enemies, ActionType.Punch, characterPosition);
        }

        public void UnravelingAttack(Party friends, Party enemies)
        {
            int characterPosition = ChooseCharacterToAttack(friends, enemies);
            Console.WriteLine($"{friends.characters[0]._name} used Unraveling on {enemies.characters[characterPosition]._name}.");
            DealHitDamage(friends, enemies, ActionType.Unraveling, characterPosition);
        }

        public void BoneCrunchAttack(Party friends, Party enemies)
        {
            int characterPosition = ChooseCharacterToAttack(friends, enemies);
            Console.WriteLine($"{friends.characters[0]._name} used Bone Crunch on {enemies.characters[characterPosition]._name}.");
            DealHitDamage(friends, enemies, ActionType.BoneCrunch, characterPosition);
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

        public void DealHitDamage(Party friends, Party enemies, ActionType action, int characterPosition)
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

            if (enemies.characters[characterPosition]._currentHealth == characterPosition) 
                RemoveCharacterFromParty(friends, enemies, enemies.characters[characterPosition], characterPosition);
        }

        public void RemoveCharacterFromParty(Party friends, Party enemies, Character character, int characterPosition)
        {
            enemies.characters.Remove(character);
            Console.WriteLine();
            Console.WriteLine($"{friends.characters[characterPosition]._name} killed {character._name}");
        }
    }
}
