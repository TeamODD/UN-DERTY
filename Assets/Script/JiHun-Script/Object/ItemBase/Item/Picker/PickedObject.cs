using UnityEngine;

namespace jjh
{
    public abstract class PickedObject : MonoBehaviour, IPickable
    {
        public void Picked(GameObject pickerObject)
        {
            if (ConcretePicked(pickerObject))
                Destroy(gameObject);
        }
        protected abstract bool ConcretePicked(GameObject pickerObject);
    }
}

