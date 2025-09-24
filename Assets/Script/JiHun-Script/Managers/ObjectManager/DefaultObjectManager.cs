using UnityEngine;

namespace jjh
{
    public class DefaultObjectManager : Singleton<DefaultObjectManager>, IObjectManager
    {
        public T Instantiate<T>(GameObject prefab, Transform parent = null) where T : MonoBehaviour
        {
            GameObject instance = GameObject.Instantiate(prefab, parent);
            return instance.GetComponent<T>();
        }
        public T Instantiate<T>(GameObject gameObject, Vector3 position, Quaternion quaternion) where T : MonoBehaviour
        {
            GameObject instance = GameObject.Instantiate(gameObject, position, quaternion);
            return instance.GetComponent<T>();
        }

        public void Destroy(GameObject gameObject, float duration = 0.0f)
        {
            GameObject.Destroy(gameObject, duration);
        }
    }
}
