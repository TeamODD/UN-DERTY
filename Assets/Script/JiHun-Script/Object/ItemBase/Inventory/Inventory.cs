using System;
using System.Collections.Generic;
using UnityEngine;

namespace jjh
{
    public class ItemSlot
    {
        public Action<ItemSlot> ActionDestroy;
        public Action<uint> ActionCountVariation;
        internal ItemSlot(ItemBase itemBase, uint currentCount, uint maxCount, Action<ItemSlot> ActionDestroy)
        {
            Item = itemBase;
            _currentCount = currentCount;
            _maxCount = maxCount;
            this.ActionDestroy = ActionDestroy;
        }
        internal bool TryAddCount(uint count)
        {
            uint sumCount = _currentCount + count;
            if (sumCount > _maxCount)
                return false;

            _currentCount = sumCount;
            ActionCountVariation?.Invoke(_currentCount);
            return true;
        }
        internal bool IsPossibleSub(uint count)
        {
            return count <= _currentCount;
        }
        internal bool TrySubCount(uint count)
        {
            if (_currentCount < count)
                return false;

            _currentCount -= count;
            ActionCountVariation?.Invoke(_currentCount);
            if (_currentCount == 0)
                Destroy();
            return true;
        }
        internal void Destroy()
        {
            _currentCount = 0;
            ActionDestroy?.Invoke(this);
        }
        public ItemBase Item { get; }
        private uint _currentCount;
        private uint _maxCount;
    }

    // 단순히 "어떠한 것"의 개수, 맥스 개수 지정해주는 놈
    // ItemBase는 그걸 위해서 존재하는 것 다른 어떠한 것도 하면 안됌
    public class Inventory : MonoBehaviour
    {
        public ItemSlot AddItem(ItemBase item, uint maxCount, uint count = 1)
        {
            if (_itemSlots.TryGetValue(item.ItemName, out ItemSlot itemSlot))
            {
                if (itemSlot.TryAddCount(count))
                    return itemSlot;
                else
                    return null;
            }
            ItemSlot slot = new ItemSlot(item, count, maxCount, DestroySlot);
            _itemSlots.Add(item.ItemName, slot);
            return slot;
        }
        public bool RemoveItem(string itemName, uint count)
        {
            if (_itemSlots.TryGetValue(itemName, out ItemSlot itemSlot))
            {
                if (itemSlot.TrySubCount(count))
                    DestroySlot(itemSlot);
                return true;
            }
            return false;
        }
        private void DestroySlot(ItemSlot slot)
        {
            _itemSlots.Remove(slot.Item.ItemName);
        }
        private Dictionary<string, ItemSlot> _itemSlots = new();
    }
}
