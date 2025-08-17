using System;
using UnityEngine;

public class VelocityCondition : ForceActivationConditionBase
{
    [SerializeField] private float judgementValue;
    [SerializeField] private Rigidbody2D rigidBody;

    public override bool PossibleActiveForce()
    {
        float absVelocityX = Math.Abs(rigidBody.linearVelocityX);
        if (absVelocityX < judgementValue)
            return true;

        return false;
    }

}
