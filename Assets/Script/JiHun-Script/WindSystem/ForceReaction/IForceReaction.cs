using UnityEngine;

public abstract class IForceReaction : MonoBehaviour
{
    public abstract void Reaction(Vector3 strength);
}