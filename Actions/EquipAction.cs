using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Enums;
using FinalBattle.Items;

namespace FinalBattle.Actions
{
    public class EquipAction : IAction
    {
        public void ComputerAction(Party friends, Party enemies, ActionType action, Character equipingCharacter)
        {
            Equip(friends, action, equipingCharacter);
        }

        public void HumanAction(Party friends, Party enemies, ActionType action, Character equipingCharacter)
        {
            Equip(friends, action, equipingCharacter);
        }

        public void Equip(Party friends, ActionType action, Character equipingCharacter)
        {
            ChooseGearToEquip(friends, equipingCharacter);
        }

        public void ChooseGearToEquip(Party friends, Character equippingCharacter)
        {
            for (int i = 0; i < friends._gear.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {friends._gear[i]._gearType}");
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            if (equippingCharacter.IsCharacterEquipped())
            {
                // add character's gear to the party first, then remove gear from character
                friends._gear.Add(equippingCharacter._gear);
                equippingCharacter._gear = new Gear(GearType.Nothing);

                // then add the gear that the character chose to equip, and remove that gear from the party's gear inventory
                equippingCharacter._gear = friends._gear[choice - 1];
                friends._gear.RemoveAt(choice - 1);
            }
            else
            {
                equippingCharacter._gear = friends._gear[choice - 1];
                // removing the item from the gear inventory after it has been attached
                friends._gear.RemoveAt(choice - 1);
            }  
        }
    }
}
