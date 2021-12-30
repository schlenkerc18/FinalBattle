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

            options = GetMenu(friends._name);
            action = GetAction(friends, options, friends._playerType);

            action.DecidePlayerAction(friends, enemies, options[0].action, friends._playerType, character);
        }

        public List<MenuItem> GetMenu(string name)
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
            
             
            MenuItem item = new MenuItem("2 - Use Potion", ActionType.UsePotion);
            options.Add(item);
            MenuItem potion = new MenuItem("3 - Do Nothing", ActionType.DoNothing);
            options.Add(potion);
            

            return options;
        }

        public IAction GetAction(Party friends, List<MenuItem> options, PlayerType playerType)
        {
            // if computer, automatically attack
            if (playerType == PlayerType.Computer) return new AttackAction();

            
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
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine("That is not a recognized action. Defaulting to attack.");
                
                choice = 1;
            }
            finally
            {
                if (choice > 3)
                {
                    Console.WriteLine("You did not choose a number from the list of provided actions. Defaulting to attack.");
                    choice = 1;
                }
            }

            if (choice == 1) return new AttackAction();
            else if (choice == 2) return new UsePotionAction();
            else return new DoNothingAction();
        }
    }
}
