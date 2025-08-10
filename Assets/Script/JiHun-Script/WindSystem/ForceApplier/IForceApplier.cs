using UnityEngine;

public abstract class IForceApplier : MonoBehaviour
{
    public abstract void Apply(ForceEntity forceEntity, ForceReactionStorage objectStorage);
}
