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
        public string _name { private set; get; }
        public int _maxHealth { private set; get; }
        public int _currentHealth { private set; get; }

        // right now, only the True Programmer is using this constructor
        public Character(string name)
        {
            _name = name;
            _maxHealth = 25;
            _currentHealth = 25;
        }

        // paramaterless constructor creates Skeleton characters
        public Character()
        {
            _name = "SKELETON";
            _maxHealth = 5;
            _currentHealth = 5;
        }

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
            Console.WriteLine("The computer is choosing an action.");
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
            AttackType attackType;

            if (friends._playerType == PlayerType.Computer)
            {
                //Console.WriteLine("1 - Bone Crunch");
                int choice = 1;

                switch (choice)
                {
                    case 1:
                        attackType = AttackType.BoneCrunch;
                        DealHitDamage(friends, enemies, attackType);
                        
                        break;
                }
            }

            else if (friends._playerType == PlayerType.Human)
            {
                Console.WriteLine();
                Console.WriteLine("Choose your attack: ");
                Console.WriteLine("1 - Punch");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        attackType = AttackType.Punch;
                        DealHitDamage(friends, enemies, attackType);
                        break;
                }
            }
        }

        /// <summary>
        /// Deals hit damage to characters, removes them if their current HP is 0
        /// </summary>
        /// <param name="friends"></param>
        /// <param name="enemies"></param>
        public void DealHitDamage(Party friends, Party enemies, AttackType attackType)
        {
            int hitDamage;

            if (attackType == AttackType.BoneCrunch)
            {
                // hit damage for bone crunch needs to randomly be 0 or 1
                Random random = new Random();
                hitDamage = random.Next(2);

                Console.WriteLine($"{_name} used Bone Crunch on {enemies.characters[0]._name}");

                // health cannot go below 0, if an attack does the same or more damage than a character has HP
                // then we set that character's HP to 0 and remove them from the game.
                if (enemies.characters[0]._currentHealth - hitDamage <= 0)
                {
                    enemies.characters[0]._currentHealth = 0;
                }
                else enemies.characters[0]._currentHealth -= hitDamage;

                Console.WriteLine($"The attack dealt {hitDamage} damage to {enemies.characters[0]._name}");
                // for testing, will remove this
                Console.WriteLine($"{enemies.characters[0]._name} is now at: {enemies.characters[0]._currentHealth}/{enemies.characters[0]._maxHealth}");

                if (enemies.characters[0]._currentHealth == 0) RemoveCharacterFromParty(enemies, enemies.characters[0]);
            }

            else if (attackType == AttackType.Punch)
            {
                // need to allow user to pick a player to attack
                hitDamage = 5;
                Console.WriteLine($"{_name} used PUNCH on {enemies.characters[0]._name}");

                if (enemies.characters[0]._currentHealth - hitDamage <= 0)
                {
                    enemies.characters[0]._currentHealth = 0;
                }
                else enemies.characters[0]._currentHealth -= hitDamage;

                Console.WriteLine($"The attack dealt {hitDamage} damage to {enemies.characters[0]._name}.");
                Console.WriteLine($"{enemies.characters[0]._name} is now at {enemies.characters[0]._currentHealth}/{enemies.characters[0]._maxHealth}");

                if (enemies.characters[0]._currentHealth == 0) RemoveCharacterFromParty(enemies, enemies.characters[0]);
            }
        }

        public void RemoveCharacterFromParty(Party enemies, Character character)
        {
            enemies.characters.Remove(character);
            Console.WriteLine($"You have killed {character._name}");
        }
    }

    

   

    
}
