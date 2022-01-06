using FinalBattle.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Items;
using FinalBattle.Enums;

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
            DealHitDamage(friends, attackingCharacter, enemies, action, characterPosition);
        }

        public int ChooseCharacterToAttack(Party friends, Party enemies)
        {
            // if there is only one enemy character, just return 0 to save tie
            if (enemies.characters.Count == 1) return 0;

            // computer chooses random player to attack
            if (friends._playerType == PlayerType.Computer)
            {
                Random random = new Random();
                return random.Next(0, enemies.characters.Count);
            }

            Console.WriteLine("Choose an enemy to attack");

            for (int i = 0; i < enemies.characters.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {enemies.characters[i]._name}");
            }

            // default attack
            int choice = 1;

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"That is not a valid response. Defaulting to attack {enemies.characters[0]._name}");
            }
            finally
            {
                if (choice > enemies.characters.Count)
                {
                    Console.WriteLine($"That is not a valid response. Defaulting to attack {enemies.characters[0]._name}");
                    choice = 1;
                }
            }
            

            // need to subtract one from choice because characters is 0 indexed
            return choice - 1;

        }

        public void DealHitDamage(Party friends, Character attackingCharacter, Party enemies, ActionType action, int characterPosition)
        {
            
            int hitDamage = 0;
            Random random = new Random();

            hitDamage = action switch
            {
                ActionType.BoneCrunch => random.Next(0,2),
                ActionType.Unraveling => random.Next(1,6),
                ActionType.Slash => 2,
                ActionType.Stab => random.Next(1,3),
                ActionType.Punch => 1,
                ActionType.QuickShot => 2,
                ActionType.Bite => random.Next(1,3)
            };
            // get damage type to pass to the attackModifier
            DamageType damageType = GetDamageType(action);

            // create attack modifier
            AttackModifier attackMod = new AttackModifier(enemies.characters[characterPosition], hitDamage, damageType);

            // after attack mod, attempt attack (attack might miss)
            hitDamage = AttemptingAttack(action, attackMod._damage);

            

            if (enemies.characters[characterPosition]._currentHealth - hitDamage <= 0)
            {
                enemies.characters[characterPosition]._currentHealth = 0;
            }
            else enemies.characters[characterPosition]._currentHealth -= hitDamage;

            Console.WriteLine($"The attack dealt {hitDamage} {damageType} damage to {enemies.characters[characterPosition]._name}.");

            Console.WriteLine($"{enemies.characters[characterPosition]._name} is now at " +
                $"{enemies.characters[characterPosition]._currentHealth}/{enemies.characters[characterPosition]._maxHealth}");

            if (enemies.characters[characterPosition]._currentHealth == 0) 
                RemoveCharacterFromParty(friends, attackingCharacter, enemies, characterPosition);
        }

        public int AttemptingAttack(ActionType action, int damage)
        {
            Random random = new Random();
            // right now quick shot is the only attack that has a change of missing

            if (action == ActionType.QuickShot)
            {
                if (random.Next(0, 2) == 0)
                {
                    Console.WriteLine("Your shot missed!");
                    return 0;
                }
                return damage;
            }
            else return damage;
        }

        public DamageType GetDamageType(ActionType action)
        {
            DamageType damageType = action switch 
            {
                ActionType.Unraveling => DamageType.Decoding,
                _ => DamageType.Normal
            };

            return damageType;
        }

        public void RemoveCharacterFromParty(Party friends, Character attackingCharacter, Party enemies, int characterPosition)
        {
            // when character is killed, move their gear to the other party
            friends._gear.Add(new Gear(enemies.characters[characterPosition]._gear._gearType));
           
            Console.WriteLine($"{attackingCharacter._name} killed {enemies.characters[characterPosition]._name}");
            Console.WriteLine($"You have acquired a {enemies.characters[characterPosition]._gear._gearType} from {enemies.characters[characterPosition]._name}");
            enemies.characters.Remove(enemies.characters[characterPosition]);
            Console.WriteLine();
        }
    }
}
