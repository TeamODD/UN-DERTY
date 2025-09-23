using UnityEngine;

namespace jjh
{
    public abstract class UseItem : ItemBase, IUsable
    {
        protected UseItem(string itemName) 
            : base(itemName)
        {
        }

        public abstract void Use(GameObject user);
    }
    public abstract class UsePassiveItem : UseItem, IPassivable
    {
        protected UsePassiveItem(string itemName) 
            : base(itemName)
        {
        }

        public abstract void AdjustPassive(GameObject owner);
        public abstract void UnAdjustPassive(GameObject owner);
    }
}

