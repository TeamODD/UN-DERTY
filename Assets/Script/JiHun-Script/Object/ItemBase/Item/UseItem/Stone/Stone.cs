using UnityEngine;

namespace jjh
{
    public class StoneItem : UsePassiveItem
    {
        public StoneItem(string itemName, SystemCaster systemCaster)
            : base(itemName)
        {
            _systemCaster = systemCaster;
        }

        public override void AdjustPassive(GameObject owner)
        {
            _effectRigidBody = owner.GetComponent<Rigidbody2D>();
            if(_effectRigidBody == null)
            {
                Debug.Log("StoneItem: Owner RigidBody Is Empty");
                return;
            }
            _effectRigidBody.mass *= 2.0f;
        }

        public override void UnAdjustPassive(GameObject owner)
        {
            Debug.Log("UnAdjustPassive Stone");
        }

        public override void Use(GameObject user)
        {
            SystemCastBase throwCast = _systemCaster.SetCurrentCast("ThrowCast");
            throwCast.ActionSuccessCast += ReleaseStoneMass;
        }

        public void ReleaseStoneMass(SystemCastBase systemCast)
        {
            _effectRigidBody.mass *= 0.5f;
            systemCast.ActionSuccessCast -= ReleaseStoneMass;
            _systemCaster.SetCurrentCast("WindCast");
        }
        private SystemCaster _systemCaster = null;
        private Rigidbody2D _effectRigidBody = null;

    }
    public class Stone : PickedObject
    {
        [SerializeField] private UseItemData _useItemData;
        [SerializeField] private SystemCaster _systemCaster;
        public void Start()
        {
            if (_useItemData == null || _systemCaster == null)
            {
                Debug.Log("Stone: Something Is None");
                return;
            }
            _stoneItem = new StoneItem(_useItemData.itemName, _systemCaster);
            _pollutableObject = GetComponent<PollutableObject>();
        }

        protected override bool ConcretePicked(GameObject pickerObject)
        {
            if (_systemCaster.IsCurrentCast("ThrowCast"))
                return false;

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

            ItemSlot refSlot = inventory.AddItem(_stoneItem, _useItemData.maxHasCount, _useItemData._useCount);

            if (refSlot == null)
                return false;

            IUsable usable = new LinkInventoryUsable(usableManager, _stoneItem, refSlot, _useItemData._useCount);
            if (usableManager.AddUsable(usable) == false)
                return false;

            IPassivable passivable = new LinkInventoryPassivable(passivableManager, _stoneItem, refSlot);
            if (passivableManager.AddPassivable(passivable) == false)
                return false;

            if(_pollutableObject.IsPollute())
            {
                // Todo: dp + 1
                Debug.Log("dp + 1");
            }

            return true;
        }

        private StoneItem _stoneItem = null;
        private PollutableObject _pollutableObject = null;
    }
}