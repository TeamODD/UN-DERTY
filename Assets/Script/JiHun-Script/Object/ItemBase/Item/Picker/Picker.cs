using UnityEngine;

namespace jjh
{
    public interface IPickable
    {
        void Picked(GameObject pickerObject);
    }
    public class Picker : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D collision)
        {
            IPickable pickable = collision.GetComponent<IPickable>();
            if (pickable != null)
            {
                pickable.Picked(gameObject);
            }
        }
    }
}