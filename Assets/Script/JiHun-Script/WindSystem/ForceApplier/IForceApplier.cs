using UnityEngine;

public abstract class IForceApplier : MonoBehaviour
{
    public abstract void Apply(ForceEntity forceEntity, ForceReactionStorage objectStorage);
    protected void activeReaction(IForceReaction forceReaction, Vector3 force)
    {
        if(forceReaction == null) return;
        if (forceReaction.PossibleReact())
        {
            Debug.Log(forceReaction);
            forceReaction.Reaction(force);
        }
    }
}
