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

            options = GetMenu(friends._name);
            ActionType action = GetAction(options, friends._playerType);

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

            
            MenuItem item = new MenuItem("2 - Do Nothing", ActionType.DoNothing);
            options.Add(item);

            return options;
        }

        public ActionType GetAction(List<MenuItem> options, PlayerType playerType)
        {
            // if computer, automatically attack
            if (playerType == PlayerType.Computer) return options[0].action;

            Console.WriteLine("Choose an action: ");
            for (int i = 0; i < options.Count; i++)
                Console.WriteLine(options[i]);

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            // need to subtract one from choice to get correct action
            return options[choice - 1].action;
        }
    }
}
