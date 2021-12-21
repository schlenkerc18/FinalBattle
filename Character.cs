using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FinalBattle
{
    public class Character
    {
        public string _name { private set; get; }
        public int _health { private set; get; }

        public Character(string name)
        {
            _name = name;
            _health = 100;
        }

        public Character()
        {
            _name = "SKELETON";
            _health = 100;
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
                        Console.WriteLine($"{_name} used Bone Crunch on {enemies.characters[0]._name}");
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
                        // need to allow user to pick a player to attack
                        Console.WriteLine($"{_name} used PUNCH on {enemies.characters[0]._name}");
                        break;
                }
            }
        }
    }

   

    
}
