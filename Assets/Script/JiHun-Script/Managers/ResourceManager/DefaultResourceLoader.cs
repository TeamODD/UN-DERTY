using System.Collections.Generic;
using UnityEngine;

namespace jjh
{
    public class DefaultResourceLoader : Singleton<DefaultResourceLoader>, IResourceLoader
    {
        public T Load<T>(string path) where T : MonoBehaviour
        {
            if (_loadedResources.TryGetValue(path, out GameObject gameObject))
                return gameObject.GetComponent<T>();

            gameObject = Resources.Load<GameObject>(path);
            _loadedResources.Add(path, gameObject);
            return gameObject.GetComponent<T>();
        }

        private Dictionary<string, GameObject> _loadedResources = new();
    }
}

