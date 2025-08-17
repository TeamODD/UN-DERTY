using System.Collections.Generic;
using UnityEngine;

public abstract class IForceApplier : MonoBehaviour
{
    [SerializeField] protected ForceReactionStorage reactionStorage;
    [SerializeField] protected float forceStrength;
    [SerializeField] protected float coefficient;
    [SerializeField] protected float maxStrength;

    public void SetForceStrength(float strength)
    {
        this.forceStrength = strength;
    }
    public float GetForceStrength()
    {
        return this.forceStrength;
    }
    public abstract void Apply(ForceEntity forceEntity);
    protected void activeReaction(IForceReaction forceReaction, Vector3 force)
    {
        if(forceReaction == null) 
            return;

        if (forceReaction.PossibleReact())
            forceReaction.Reaction(force);
    }
}