using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Menus
{
    public class CreateMenu
    {
        public void GetMenuItems(Party friends)
        {
            string[] choices;

            if (friends._name == "Heroes") choices = GetHeroMenu();
            else if (friends._name == "Monsters") choices = GetMonsterMenu();
            else choices = GetUncodedOneMenu();

            List<MenuItem> menu = new List<MenuItem>();

            for (int i = 0; i < choices.Length; i++)
            {
                //MenuItem menuItem = new MenuItem();
            }
        }

        public string[] GetHeroMenu()
        {
            string[] choices = new string[2];

            choices[0] = "1 - Punch (Standard Attack)";
            choices[1] = "2 - Do Nothing";

            return choices;
        }

        public string[] GetMonsterMenu()
        {
            string[] choices = new string[2];

            choices[0] = "1 - Bone Crunch (Standard Attack)";
            choices[1] = "2 - Do Nothing";

            return choices;
        }

        public string[] GetUncodedOneMenu()
        {
            string[] choices = new string[2];

            choices[0] = "1 - Unraveling (Standard Attack)";
            choices[1] = "2 - Do Nothing";

            return choices;
        }
    }
}
