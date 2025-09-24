using System;
using UnityEngine;

namespace jjh
{
    public abstract class PickedObject : MonoBehaviour, IPickable
    {
        public Action ActionPicked;
        public void Picked(GameObject pickerObject)
        {
            if (ConcretePicked(pickerObject))
            {
                ActionPicked?.Invoke();
                Destroy(gameObject);
            }
        }
        protected abstract bool ConcretePicked(GameObject pickerObject);
    }
}

