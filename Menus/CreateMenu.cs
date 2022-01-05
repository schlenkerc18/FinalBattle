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

            MenuItem menuItem = name switch
            {
                "Heroes" => new MenuItem("1 - Punch (Standard Attack)", ActionType.Punch),
                "Monsters" => new MenuItem("1 - Bone Crunch (Standard Attack)", ActionType.BoneCrunch),
                "The Uncoded One" => new MenuItem("1 - Unraveling (Standard Attack)", ActionType.Unraveling),
                "Stone Amaroks" => new MenuItem("1 - Bite (Standard Attack)", ActionType.Bite)
            };

            options.Add(menuItem);

            // using this variable to print the correct option number in front of the option, starting at 2 because every character will always have at least 1 option
            int optionNumber = 2;

            // add option for character to use a special attack based on what gear they have equipped
            if (character.IsCharacterEquipped())
            {
                MenuItem specialAttack = character._gear._gearType switch
                {
                    GearType.Dagger => new MenuItem($"{optionNumber} - Stab", ActionType.Stab),
                    GearType.Sword => new MenuItem($"{optionNumber} - Slash", ActionType.Slash),
                    GearType.Bow => new MenuItem($"{optionNumber} - Quick Shot", ActionType.QuickShot)
                };

                options.Add(specialAttack);
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
                ActionType.Equip => new EquipAction(),
                ActionType.QuickShot => new AttackAction()
            };

            return (action, options[choice - 1].action);
        }

        public (IAction, ActionType) GetComputerAction(Party friends, List<MenuItem> options, Character character)
        {
            Random rand = new Random();

            // if character health is below 50%, then they should use a potion if they have a potion available 25% of the time
            if (character._currentHealth <= character._maxHealth / 2)
                if (rand.Next(0, 4) == 0  & friends._items.Count != 0) 
                    return (new UsePotionAction(), ActionType.UsePotion);

            // character should be equipping gear 50% when they have not used a potion
            if (!character.IsCharacterEquipped() & character._name.Contains("SKELETON"))
                if (rand.Next(0,2) == 0) 
                    return (new EquipAction(), ActionType.Equip);

            // if character has gear, then they should special attack
            if (character.IsCharacterEquipped() & (character._characterType == CharacterType.Skeleton || character._characterType == CharacterType.TrueProgrammer || character._characterType == CharacterType.HeroCompanion))
            {
                switch (character._characterType)
                {
                    case CharacterType.Skeleton:
                        return (new AttackAction(), ActionType.Stab);
                    case CharacterType.HeroCompanion:
                        return (new AttackAction(), ActionType.QuickShot);
                    case CharacterType.TrueProgrammer:
                        return (new AttackAction(), ActionType.Slash);
                }
            }
                

            // return attack action if computer health is above 50%
            return (new AttackAction(), options[0].action);
        }
    } 
}
