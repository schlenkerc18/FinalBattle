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
        public void GetMenuItems(Party friends, Party enemies)
        {
            List<MenuItem> options;
            AttackAction attack;

            if (friends._name == "Heroes")
            {
                options = GetHeroMenu();


                if (friends._playerType == PlayerType.Human)
                {
                    ActionType action = GetAction(options);

                    if (action != ActionType.DoNothing)
                    {
                        
                        attack = new AttackAction();
                        attack.PlayerAction(friends, enemies, action);
                    }
                    else
                    {
                        DoNothingAction doNothing = new DoNothingAction();
                        doNothing.PlayerAction(friends, enemies, action);
                    }
                }

                else
                {
                    ActionType action = options[0].action;
                    attack = new AttackAction();
                    attack.ComputerAction(friends, enemies, action);
                }
            }

            else if (friends._name == "Monsters")
            {
                options = GetMonsterMenu();

                if (friends._playerType == PlayerType.Human)
                {
                    ActionType action = GetAction(options);

                    if (action != ActionType.DoNothing)
                    {
                        attack = new AttackAction();
                        attack.PlayerAction(friends, enemies, action);
                    }
                    else
                    {
                        DoNothingAction doNothing = new DoNothingAction();
                        doNothing.PlayerAction(friends, enemies, action);
                    }
                }
                else
                {
                    ActionType action = options[0].action;
                    attack = new AttackAction();
                    attack.ComputerAction(friends, enemies, action);
                }
            }

            else
            {
                options = GetUncodedOneMenu();
                

                if (friends._playerType == PlayerType.Human)
                {
                    ActionType action = GetAction(options);

                    if (action != ActionType.DoNothing)
                    {
                        attack = new AttackAction();
                        attack.PlayerAction(friends, enemies, action);
                    }
                    else
                    {
                        DoNothingAction doNothing = new DoNothingAction();
                        doNothing.PlayerAction(friends, enemies, action);
                    }
                }
                else
                {
                    ActionType action = options[0].action;
                    attack = new AttackAction();
                    attack.ComputerAction(friends, enemies, action);
                }
            }
        }

        public List<MenuItem> GetHeroMenu()
        {
            List<MenuItem> options = new List<MenuItem>();

            MenuItem menuItem = new MenuItem("1 - Punch (Standard Attack)", ActionType.Punch);
            options.Add(menuItem);
            menuItem = new MenuItem("2 - Do Nothing", ActionType.DoNothing);
            options.Add(menuItem);

            return options;
        }

        public List<MenuItem> GetMonsterMenu()
        {
            List<MenuItem> options = new List<MenuItem>();

            MenuItem menuItem = new MenuItem("1 - Bone Crunch (Standard Attack)", ActionType.BoneCrunch);
            options.Add(menuItem);
            menuItem = new MenuItem("2 - Do Nothing", ActionType.DoNothing);
            options.Add(menuItem);

            return options;
        }

        public List<MenuItem> GetUncodedOneMenu()
        {
            List<MenuItem> options = new List<MenuItem>();

            MenuItem menuItem = new MenuItem("1 - Unraveling (Standard Attack)", ActionType.Unraveling);
            options.Add(menuItem);
            menuItem = new MenuItem("2 - Do Nothing", ActionType.DoNothing);
            options.Add(menuItem);

            return options;
        }

        public ActionType GetAction(List<MenuItem> options)
        {
            for (int i = 0; i < options.Count; i++)
                Console.WriteLine(options[i]);

            int choice = Convert.ToInt32(Console.ReadLine());

            // need to subtract one from choice to get correct action
            return options[choice - 1].action;
        }
    }
}
