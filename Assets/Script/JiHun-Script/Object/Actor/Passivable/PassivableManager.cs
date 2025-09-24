using System.Collections.Generic;
using UnityEngine;

namespace jjh
{
    public interface IPassivable
    {
        void AdjustPassive(GameObject owner);
        void UnAdjustPassive(GameObject owner);
    }
    public class PassivableManager : MonoBehaviour
    {
        public bool AddPassivable(IPassivable passivable)
        {
            _passivables.Add(passivable);
            passivable.AdjustPassive(this.gameObject);
            return true;
        }
        public bool RemovePassivable(IPassivable passivable)
        {
            passivable.UnAdjustPassive(this.gameObject);
            _passivables.Remove(passivable);
            return true;
        }
        private List<IPassivable> _passivables = new();
    }
    public class LinkInventoryPassivable : IPassivable
    {
        public LinkInventoryPassivable(PassivableManager owner, IPassivable passivable, ItemSlot refSlot)
        {
            _owner = owner;
            _passivable = passivable;

            refSlot.ActionDestroy += RegistTerminate;
        }

        public void AdjustPassive(GameObject owner)
        {
            _passivable.AdjustPassive(owner);
        }

        public void UnAdjustPassive(GameObject owner)
        {
            _passivable.UnAdjustPassive(owner);
        }
        private void RegistTerminate(ItemSlot slot)
        {
            slot.ActionDestroy -= RegistTerminate;
            _owner.RemovePassivable(this);
        }

        private PassivableManager _owner;
        private IPassivable _passivable;

    }
}