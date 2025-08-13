using UnityEngine;

public abstract class IForceApplier : MonoBehaviour
{
    [SerializeField] protected ForceReactionStorage reactionStorage;
    public abstract void Apply(ForceEntity forceEntity);
    protected void activeReaction(IForceReaction forceReaction, Vector3 force)
    {
        if(forceReaction == null) 
            return;

        if (forceReaction.PossibleReact())
            forceReaction.Reaction(force);
    }
}
