using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // attaching gear and subtracting one for correct index
            equippingCharacter._gear = friends._gear[choice - 1];
            // removing the item from the gear inventory after it has been attached
            friends._gear.RemoveAt(choice - 1);
        }
    }
}
