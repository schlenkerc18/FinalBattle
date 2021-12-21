using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // TODO: Let the player choose what type of characters to add
            for (int i = 0; i < numberOfCharacters; i++)
            {
                Character character = new Character();
                characters.Add(character);
            }
        }

        public void AddTrueProgrammer()
        {
            Console.Write("What name do you want to use for your character?: ");
            string name = Console.ReadLine();
            Character character = new Character(name);
            characters.Add(character);
        }
    }
}
