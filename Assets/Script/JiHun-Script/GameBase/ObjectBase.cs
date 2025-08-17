using UnityEngine;
using System.Collections.Generic;
using System.Linq; // LINQ를 사용하기 위해 추가

public class ObjectBase : MonoBehaviour
{
    private List<ObjectComponent> components = new List<ObjectComponent>();
    public void AddObjectComponent(ObjectComponent component)
    {
        components.Add(component);
    }

    public T GetObjectComponent<T>() where T : ObjectComponent
    {
        return components.FirstOrDefault(c => c is T) as T;
    }
}
