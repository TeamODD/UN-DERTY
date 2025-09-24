using System.Collections.Generic;
using UnityEngine;

namespace jjh
{
    public interface IUsable
    {
        void Use(GameObject user);
    }
    public class UsableManager : MonoBehaviour
    {
        private void Start()
        {
            InputManager.Instance.AddInputEvent(KeyCode.R, EKeyState.GetKeyUp, UseCurrentUsable);
        }
        public bool AddUsable(IUsable usable)
        {
            if(_usables.Contains(usable))
            {
                Debug.Log("UsableManager: Same Usable Pushed");
                return false;
            }
            _usables.Add(usable);
            if (_currentUsable == null)
                ElectCurrentUsable();
            return true;
        }
        public bool RemoveUsable(IUsable usable)
        {
            if (_usables.Contains(usable) == false)
                return false;

            _usables.Remove(usable);
            if (_currentUsable == usable)
                ElectCurrentUsable();
            return true;
        }
        public void ElectCurrentUsable()
        {
            if (_usables.Count == 0)
            {
                _currentUsable = null;
                return;
            }
            _currentUsable = _usables[0];
        }
        private void UseCurrentUsable(InputValue inputValue)
        {
            if (_currentUsable == null)
                return;
            _currentUsable.Use(gameObject);
        }
        
        private List<IUsable> _usables = new();
        private IUsable _currentUsable = null;
    }
    public class LinkInventoryUsable : IUsable
    {
        public LinkInventoryUsable(UsableManager owner, IUsable usable, ItemSlot refSlot, uint useCount)
        {
            _owner = owner;
            _usable = usable;
            _refSlot = refSlot;
            _useCount = useCount;

            _refSlot.ActionDestroy += RegistTerminate;
        }
        public void Use(GameObject user)
        {
            if(_refSlot.IsPossibleSub(_useCount))
            {
                _usable.Use(user);
                _refSlot.TrySubCount(_useCount);
            }
        }
        private void RegistTerminate(ItemSlot slot)
        {
            slot.ActionDestroy -= RegistTerminate;
            _owner.RemoveUsable(this);
        }
        private UsableManager _owner;
        private IUsable _usable;
        private ItemSlot _refSlot;
        private uint _useCount;
    }


}
