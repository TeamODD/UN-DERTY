using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ForceReactionPair
{
    public GameObject key;
    public IForceReaction value;
}

public class ForceReactionStorage : MonoBehaviour
{
    [SerializeField] private List<ForceReactionPair> forceReactionPairList;
    
    public ForceReactionStorage()
    {
        applyForceObjects = new Dictionary<int, IForceReaction>();
    }
    public void Awake()
    {
        applyForceObjects = new Dictionary<int, IForceReaction>();
        foreach (var pair in forceReactionPairList)
        {
            int id = pair.key.GetInstanceID();
            applyForceObjects.Add(id, pair.value);
        }
    }
    public void RemoveApplyObject(GameObject applyObject)
    {
        int id = applyObject.GetInstanceID();
        applyForceObjects.Remove(id);
    }

    public IForceReaction ReturnObjectForceReactionOrNull(GameObject gameObject)
    {
        int id = gameObject.GetInstanceID();
        if (applyForceObjects.ContainsKey(id) == false)
            return null;

        return applyForceObjects[id];
    }

    public int StorageCount() { return applyForceObjects.Count; }
    private Dictionary<int, IForceReaction> applyForceObjects;
}

