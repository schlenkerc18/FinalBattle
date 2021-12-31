using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Characters;
using FinalBattle.Items;
using FinalBattle.Enums;

namespace FinalBattle
{
    public class Party
    {
        public List<Character> characters = new List<Character>();
        public string _name { private set; get; }
        public PlayerType _playerType { private set; get; }
        public List<ItemType> _items;

        public Party(PlayerType playerType, string name, int charactersToAdd, int itemsToAdd)
        {
            _name = name;
            _playerType = playerType;
            _items = new List<ItemType>();

            FillItemInventory(itemsToAdd);

            if (name == "Heroes")
            {
                AddTrueProgrammer();
                AddCharacters(charactersToAdd - 1);
            }

            else if (name == "The Uncoded One")
            {
                UncodedOne uncodedOne = new UncodedOne();
                characters.Add(uncodedOne);
            }

            else AddCharacters(charactersToAdd);
        }

        public void FillItemInventory(int itemsToAdd)
        {
            for (int i = 0; i < itemsToAdd; i++)
            {
                _items.Add(ItemType.Potion);
            }
        }

        public void AddCharacters(int numberOfCharacters)
        {
            //currently just adding skeletons
            //for (int i = 0; i < numberOfCharacters; i++)
            //{
            //    Skeleton skeleton = new Skeleton();
            //    characters.Add(skeleton);
            //}
            Skeleton skeleton = new Skeleton("Skeleton1");
            characters.Add(skeleton);

            if (numberOfCharacters == 2)
            {
                skeleton = new Skeleton("Skeleton2");
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
