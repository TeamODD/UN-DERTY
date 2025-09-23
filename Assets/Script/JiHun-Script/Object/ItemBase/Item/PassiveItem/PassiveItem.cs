using UnityEngine;

namespace jjh
{
    public abstract class PassiveItem : ItemBase, IPassivable
    {
        protected PassiveItem(string itemName) 
            : base(itemName)
        {
        }

        public abstract void AdjustPassive(GameObject owner);
        public abstract void UnAdjustPassive(GameObject owner);
    }
}