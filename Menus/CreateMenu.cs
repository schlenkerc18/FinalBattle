using FinalBattle.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Enums;

namespace FinalBattle.Menus
{
    public class CreateMenu
    {
        public void GetMenuItems(Party friends, Party enemies, Character character)
        {
            List<MenuItem> options;
            IAction action;
            ActionType actionType;

            options = GetMenu(friends, friends._name, character);
            (action, actionType) = GetAction(friends, options, friends._playerType, character);

            action.DecidePlayerAction(friends, enemies, actionType, friends._playerType, character);
        }

        public List<MenuItem> GetMenu(Party friends, string name, Character character)
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

            // using this variable to print the correct option number in front of the option, starting at 2 because every character will always have at least 1 option
            int optionNumber = 2;

            // add option for character to use a special attack based on what gear they have equipped
            if (character.IsCharacterEquipped())
            {
                if (character._gear._gearType == GearType.Dagger)
                {
                    MenuItem stab = new MenuItem($"{optionNumber} - Stab", ActionType.Stab);
                    options.Add(stab);
                }

                if (character._gear._gearType == GearType.Sword)
                {
                    MenuItem slash = new MenuItem($"{optionNumber} - Slash", ActionType.Slash);
                    options.Add(slash);
                }

                optionNumber++;
            }

            // everybody has option to use potion or do nothing
            MenuItem item = new MenuItem($"{optionNumber} - Use Potion", ActionType.UsePotion);
            options.Add(item);
            optionNumber++;

            MenuItem potion = new MenuItem($"{optionNumber} - Do Nothing", ActionType.DoNothing);
            options.Add(potion);
            optionNumber++;

            
            // only add option to equip weapon if they have weapon in their gear inventory
            if (friends._gear.Count != 0)
            {
                MenuItem equip = new MenuItem($"{optionNumber} - Equip Weapon", ActionType.Equip);
                options.Add(equip);
                optionNumber++;
            }

            return options;
        }

        public (IAction, ActionType) GetAction(Party friends, List<MenuItem> options, PlayerType playerType, Character character)
        {
            // if computer, automatically attack
            if (playerType == PlayerType.Computer) return GetComputerAction(friends, options, character);

            Console.WriteLine("Choose an action: ");
            for (int i = 0; i < options.Count; i++)
                Console.WriteLine(options[i]);

            int choice = 0;

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());

                while (options[choice - 1].action == ActionType.UsePotion & friends._items.Count == 0)
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
                if (choice > options.Count())
                {
                    Console.WriteLine("You did not choose a number from the list of provided actions. Defaulting to attack.");
                    choice = 1;
                }
            }

            IAction action = options[choice - 1].action switch
            {
                ActionType.BoneCrunch => new AttackAction(),
                ActionType.Punch => new AttackAction(),
                ActionType.Unraveling => new AttackAction(),
                ActionType.Slash => new AttackAction(),
                ActionType.Stab => new AttackAction(),
                ActionType.UsePotion => new UsePotionAction(),
                ActionType.DoNothing => new DoNothingAction(),
                ActionType.Equip => new EquipAction()
            };

            return (action, options[choice - 1].action);
        }

        public (IAction, ActionType) GetComputerAction(Party friends, List<MenuItem> options, Character character)
        {
            // if character health is below 50%, then they should use a potion if they have a potion available 25% of the time
            if (character._currentHealth <= character._maxHealth / 2)
            { 
                Random rand = new Random();
                if (rand.Next(0, 4) == 0  & friends._items.Count != 0) return (new UsePotionAction(), ActionType.UsePotion);
                else return (new AttackAction(), options[0].action);
            }

            // return attack action if computer health is above 50%
            return (new AttackAction(), options[0].action);
        }
    } 
}
