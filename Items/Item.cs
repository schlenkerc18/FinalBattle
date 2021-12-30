using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Enums;

namespace FinalBattle.Items
{
    public class Item
    {
        public ItemType _itemType { get; private set; }
        public int _itemCount { get; private set; }

        public Item(ItemType itemType, int itemCount)
        {
            _itemType = itemType;
            _itemCount = itemCount;
        }

        
    }
}
