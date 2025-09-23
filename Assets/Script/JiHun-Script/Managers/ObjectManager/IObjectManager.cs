using UnityEngine;

namespace jjh
{
    public interface IObjectManager
    {
        public T Instantiate<T>(GameObject prefab, Transform parent = null) where T : MonoBehaviour;
        public T Instantiate<T>(GameObject gameObject, Vector3 position, Quaternion quaternion) where T : MonoBehaviour;
        public void Destroy(GameObject gameObject, float duration = 0.0f);
    }
}
