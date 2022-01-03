using FinalBattle.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Menus
{
    public class CreateMenu
    {
        public void GetMenuItems(Party friends, Party enemies, Character character)
        {
            List<MenuItem> options;
            IAction action;

            options = GetMenu(friends, friends._name);
            action = GetAction(friends, options, friends._playerType, character);

            action.DecidePlayerAction(friends, enemies, options[0].action, friends._playerType, character);
        }

        public List<MenuItem> GetMenu(Party friends, string name)
        {
            List<MenuItem> options = new List<MenuItem>();

            if (name == "Heroes")
            {
                MenuItem menuItem = new MenuItem("1 - Punch (Standard Attack)", ActionType.Punch);
                options.Add(menuItem);
            }
            else if (name == "Monsters")
            {
                MenuItem menuItem = new MenuItem("1 - Bone Crunch (Standard Attack)", ActionType.BoneCrunch);
                options.Add(menuItem);
            }
            else
            {
                MenuItem menuItem = new MenuItem("1 - Unraveling (Standard Attack)", ActionType.Unraveling);
                options.Add(menuItem);
            }
            
            // everybody has option to use potion or do nothing
            MenuItem item = new MenuItem("2 - Use Potion", ActionType.UsePotion);
            options.Add(item);
            MenuItem potion = new MenuItem("3 - Do Nothing", ActionType.DoNothing);
            options.Add(potion);

            // only add option to equip weapon if they have weapon in their gear inventory
            if (friends._gear.Count != 0)
            {
                MenuItem equip = new MenuItem("4 - Equip Weapon", ActionType.Equip);
                options.Add(equip);
            }

            return options;
        }

        public IAction GetAction(Party friends, List<MenuItem> options, PlayerType playerType, Character character)
        {
            // if computer, automatically attack
            if (playerType == PlayerType.Computer) return GetComputerAction(friends, character);

            Console.WriteLine("Choose an action: ");
            for (int i = 0; i < options.Count; i++)
                Console.WriteLine(options[i]);

            int choice = 0;

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());

                while (choice == 2 & friends._items.Count == 0)
                {
                    Console.WriteLine("You have no potions left.  Please choose another action.");
                    foreach (var option in options)
                        Console.WriteLine(option);
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("That is not a recognized action. Defaulting to attack.");
                
                choice = 1;
            }
            finally
            {
                if (choice > 4)
                {
                    Console.WriteLine("You did not choose a number from the list of provided actions. Defaulting to attack.");
                    choice = 1;
                }
            }

            if (choice == 1) return new AttackAction();
            else if (choice == 2) return new UsePotionAction();
            else if (choice == 3) return new DoNothingAction();
            else return new EquipAction();
        }

        public IAction GetComputerAction(Party friends, Character character)
        {
            // if character health is below 50%, then they should use a potion if they have a potion available 25% of the time
            if (character._currentHealth <= character._maxHealth / 2)
            { 
                Random rand = new Random();
                if (rand.Next(0, 4) == 0  & friends._items.Count != 0) return new UsePotionAction();
                else return new AttackAction();
            }

            // return attack action if computer health is above 50%
            return new AttackAction();
        }
    } 
}
