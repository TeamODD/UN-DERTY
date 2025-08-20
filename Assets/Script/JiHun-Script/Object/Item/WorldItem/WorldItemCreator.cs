using System;
using UnityEngine;

public class WorldItemCreator : MonoBehaviour
{
    [SerializeField] private WorldItem worldItem;
    public event Action<WorldItem> OnCreate;
    public WorldItem CreateWorldStone(Transform transform)
    {
        WorldItem realObject= Instantiate(worldItem, transform);
        OnCreate?.Invoke(realObject);

        return realObject;
    }
}
