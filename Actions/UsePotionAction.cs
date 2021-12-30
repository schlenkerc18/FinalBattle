﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Items;
using FinalBattle.Enums;

namespace FinalBattle.Actions
{
    class UsePotionAction : IAction
    {

        public void HumanAction(Party friends, Party enemies, ActionType action, Character character)
        {
            UsePotion(friends, ItemType.Potion, character);
        }

        public void ComputerAction(Party friends, Party enemies, ActionType action, Character character)
        {
            UsePotion(friends, ItemType.Potion, character);
        }

        public void UsePotion(Party party, ItemType itemType, Character character)
        {
            if (party._items.Count == 0)
            {
                Console.WriteLine("You do not have any items in your inventory.");
            }

            else
            {
                switch (itemType)
                {
                    case ItemType.Potion:
                        if (character._currentHealth + 10 > character._maxHealth) character._currentHealth = character._maxHealth;
                        else character._currentHealth += 10;
                        break;
                }

                party._items.Remove(itemType);
            }
        }
    }
}