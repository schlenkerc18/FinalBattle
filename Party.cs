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
        public List<Gear> _gear;

        public Party(PlayerType playerType, string name, int charactersToAdd, int itemsToAdd, int gearToAdd)
        {
            _name = name;
            _playerType = playerType;
            _items = new List<ItemType>();
            _gear = new List<Gear>();

            FillItemInventory(itemsToAdd);
            FillGearInventory(name, gearToAdd);

            if (name == "Heroes") AddTrueProgrammer();

            else if (name == "The Uncoded One")
            {
                UncodedOne uncodedOne = new UncodedOne();
                characters.Add(uncodedOne);
            }

            else AddSkeletons(charactersToAdd);
        }

        public void FillItemInventory(int itemsToAdd)
        {
            for (int i = 0; i < itemsToAdd; i++)
            {
                _items.Add(ItemType.Potion);
            }
        }

        public void FillGearInventory(string name, int gearToAdd)
        {
            // only skeletons need gear right now

            if (name == "Monsters")
            {
                for (int i = 0; i < gearToAdd; i++)
                {
                    Gear gear = new Gear(GearType.Dagger);
                    _gear.Add(gear);
                }
            }
            
        }

        public void AddSkeletons(int numberOfCharacters)
        {
            for (int i = 0; i < numberOfCharacters; i++)
            {
                Skeleton skeleton = new Skeleton($"SKELETON {i+1}");
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
