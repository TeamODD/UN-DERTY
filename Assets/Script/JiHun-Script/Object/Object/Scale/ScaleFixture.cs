using UnityEngine;

namespace jjh
{
    public class ScaleFixture : MonoBehaviour
    {
        [SerializeField] private GameObject _scaleObject;
        void Update()
        {
            float y = transform.position.y + transform.localScale.y;
            Vector3 fixPosition = new Vector3(transform.position.x, y, transform.position.z);
            _scaleObject.transform.position = fixPosition;
        }
    }

}
