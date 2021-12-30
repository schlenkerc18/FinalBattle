using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FinalBattle
{

    // TODO: I think we want to create an inheritance heirarchy here.
    // Might be a good idea to have a character class, and then a Skeleton,
    // TrueProgrammer and UncodedOne classes that inherit from the Character classs

    public class Character
    {
        public string _name { set; get; }
        public int _maxHealth { set; get; }
        public int _currentHealth { set; get; }

        /// <summary>
        /// Allows player to choose action
        /// </summary>
        /// <param name="party"></param>
        /// <returns></returns>
        public ActionType PlayerAction(Party friends, Party enemies)
        {
            Console.WriteLine("Choose your action.");
            Console.WriteLine("1 - Do Nothing");
            Console.WriteLine("2 - Attack");
            int choice = Convert.ToInt32(Console.ReadLine());

            return GetAction(choice, friends, enemies);
        }

        /// <summary>
        /// Computer picks an action at random
        /// </summary>
        /// <param name="party"></param>
        /// <returns></returns>
        public ActionType ComputerAction(Party friends, Party enemies)
        {
            //Console.WriteLine("The computer is choosing an action.");
            Random rand = new Random();
            //int choice = rand.Next(0, 3); might want some randomness in the future, for now we are just going to have the cpu attack
            int choice = 2;
            Thread.Sleep(1000);
            return GetAction(choice, friends, enemies);
        }

        /// <summary>
        /// Runs the given action that the player or computer chose
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="friends"></param>
        /// <param name="enemies"></param>
        /// <returns></returns>
        public ActionType GetAction(int choice, Party friends, Party enemies)
        {
            ActionType action;

            switch (choice)
            {
                case 1:
                    action = ActionType.DoNothing;
                    Console.WriteLine($"{_name} did nothing.");
                    break;
                case 2:
                    action = ActionType.Attack;
                    ChooseAttack(friends, enemies);
                    break;
                default:
                    action = ActionType.DoNothing;
                    Console.WriteLine($"{_name} did nothing.");
                    break;
            }

            return action;
        }

        /// <summary>
        /// Lets the current player choose an enemy to attack
        /// Currently, the skeletons automatically use "Bone crunch"
        /// and the human's only choice is "Punch"
        /// </summary>
        /// <param name="party"></param>
        public void ChooseAttack(Party friends, Party enemies)
        {
            ActionType action;

            if (friends._playerType == PlayerType.Computer)
            {
                int choice;
                if (friends.characters[0]._name == "SKELETON") choice = 1;
                else if (friends.characters[0]._name == "The Uncoded One") choice = 2;
                else choice = 3;

                switch (choice)
                {
                    case 1:
                        action = ActionType.BoneCrunch;
                        Console.WriteLine($"{_name} used Bone Crunch on {enemies.characters[0]._name}");
                        DealHitDamage(friends, enemies, action);
                        break;
                    case 2:
                        action = ActionType.Unraveling;
                        Console.WriteLine($"{_name} used Unraveling on {enemies.characters[0]._name}");
                        DealHitDamage(friends, enemies, action);
                        break;
                    case 3:
                        action = ActionType.Punch;
                        Console.WriteLine($"{_name} used Punch on {enemies.characters[0]._name}");
                        DealHitDamage(friends, enemies, action);
                        break;
                }
            }

            else if (friends._playerType == PlayerType.Human)
            {
                if (friends.characters[0]._name == "SKELETON") SkeletonAttack(friends, enemies);
                else if (friends.characters[0]._name == "The Uncoded One") UncodedOneAttack(friends, enemies);
                else TrueProgramerAttack(friends, enemies);
            }
        }

        public void SkeletonAttack(Party friends, Party enemies)
        {
            Console.WriteLine();
            Console.WriteLine("Choose your attack: ");
            Console.WriteLine("1 - Bone Crunch");
            int choice = Convert.ToInt32(Console.ReadLine());

            ActionType ActionType = ActionType.BoneCrunch;
            Console.WriteLine($"{_name} used Bone Crunch on {enemies.characters[0]._name}");
            DealHitDamage(friends, enemies, ActionType);
        }

        public void UncodedOneAttack(Party friends, Party enemies)
        {
            Console.WriteLine();
            Console.WriteLine("Choose your attack: ");
            Console.WriteLine("1 - Unraveling");
            int choice = Convert.ToInt32(Console.ReadLine());

            ActionType ActionType = ActionType.Unraveling;
            Console.WriteLine($"{_name} used Unraveling on {enemies.characters[0]._name}");
            DealHitDamage(friends, enemies, ActionType);
        }

        public void TrueProgramerAttack(Party friends, Party enemies)
        {
            Console.WriteLine();
            Console.WriteLine("Choose your attack: ");
            Console.WriteLine("1 - Punch");
            int choice = Convert.ToInt32(Console.ReadLine());

            ActionType ActionType = ActionType.Punch;
            Console.WriteLine($"{_name} used Punch on {enemies.characters[0]._name}");
            DealHitDamage(friends, enemies, ActionType);
        }

        /// <summary>
        /// Deals hit damage to characters, removes them if their current HP is 0
        /// </summary>
        /// <param name="friends"></param>
        /// <param name="enemies"></param>
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
