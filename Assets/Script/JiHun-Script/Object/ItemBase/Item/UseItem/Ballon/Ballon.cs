using UnityEngine;

namespace jjh
{
    public class BallonItem : UsePassiveItem
    {
        public BallonItem(string itemName, WindCast windCast, float multipleValue) 
            : base(itemName)
        {
            _windCast = windCast;
            _multipleValue = multipleValue;
        }

        public override void AdjustPassive(GameObject owner)
        {
            Rigidbody2D rb = owner.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.mass *= 0.5f;
        }

        public override void UnAdjustPassive(GameObject owner)
        {
            Rigidbody2D rb = owner.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.mass *= 2.0f;
        }

        public override void Use(GameObject user)
        {
            _windCast.AddMultiplyStrengthValue(_multipleValue);
        }

        private WindCast _windCast = null;
        private float _multipleValue;
    }
    public class Ballon : PickedObject
    {
        [SerializeField] private UseItemData _useItemData;
        [SerializeField] private WindCast _windCast;
        [SerializeField] private float _windMultipleValue = 1.5f;
        private BallonItem _ballonItem;
        private void Start()
        {
            if (_useItemData == null || _windCast == null)
            {
                Debug.Log("Ballon: Something Is None");
                return;
            }
        }
        protected override bool ConcretePicked(GameObject pickerObject)
        {
            Inventory inventory = pickerObject.GetComponent<Inventory>();
            if (inventory == null)
                return false;

            PassivableManager passivableManager = pickerObject.GetComponent<PassivableManager>();
            if (passivableManager == null)
                return false;

            UsableManager usableManager = pickerObject.GetComponent<UsableManager>();
            if (usableManager == null)
                return false;

            //////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            _ballonItem = new BallonItem(_useItemData.itemName, _windCast, _windMultipleValue);

            ItemSlot refSlot = inventory.AddItem(_ballonItem, _useItemData.maxHasCount, _useItemData._useCount);
            if (refSlot == null)
                return false;

            IUsable usable = new LinkInventoryUsable(usableManager, _ballonItem, refSlot, _useItemData._useCount);
            if (usableManager.AddUsable(usable) == false)
                return false;

            IPassivable passivable = new LinkInventoryPassivable(passivableManager, _ballonItem, refSlot);
            if (passivableManager.AddPassivable(passivable) == false)
                return false;

            return true;
        }
    }
}

