using UnityEngine;

namespace jjh
{
    public interface IResourceLoader
    {
        public T Load<T>(string path) where T : MonoBehaviour;
    }
}
