using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public static ObjectCreator Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public GameObject CreateObjectOrNull(GameObject prefab, Vector3 position)
    {
        if (prefab == null)
            return null;
        return Instantiate(prefab, position, Quaternion.identity);
    }
}
