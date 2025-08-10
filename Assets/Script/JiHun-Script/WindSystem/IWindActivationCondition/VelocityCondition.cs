using System;
using UnityEngine;

public class VelocityCondition : IWindActivationCondition
{
    [SerializeField] private float judgementValue = 0.0f;
    [SerializeField] private Rigidbody2D rigidBody;

    public override bool PossibleWind()
    {
        float absVelocityX = Math.Abs(rigidBody.linearVelocityX);
        if (absVelocityX < judgementValue)
            return true;

        return false;
    }

}
