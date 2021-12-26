using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Characters;

namespace FinalBattle
{
    public class Party
    {
        public List<Character> characters = new List<Character>();
        public string _name { private set; get; }
        public PlayerType _playerType { private set; get; }

        public Party(PlayerType playerType, string name, int charactersToAdd)
        {
            _name = name;
            _playerType = playerType;

            if (name == "Heroes")
            {
                AddTrueProgrammer();
                AddCharacters(charactersToAdd - 1);
            }

            else AddCharacters(charactersToAdd);
        }

        public void AddCharacters(int numberOfCharacters)
        {
            // currently just adding skeletons
            for (int i = 0; i < numberOfCharacters; i++)
            {
                Skeleton skeleton = new Skeleton();
                characters.Add(skeleton);
            }
        }

        public void AddTrueProgrammer()
        {
            Console.Write("What name do you want to use for your character?: ");
            string name = Console.ReadLine();
            TrueProgrammer trueProgrammer = new TrueProgrammer(name);
            characters.Add(trueProgrammer);
        }
    }
}
