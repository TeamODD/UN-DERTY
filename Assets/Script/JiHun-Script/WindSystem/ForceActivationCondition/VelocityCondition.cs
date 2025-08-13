using System;
using UnityEngine;

public class VelocityCondition : ForceActivationConditionBase
{
    [SerializeField] private MouseManager mouseManager;
    [SerializeField] private float judgementValue;
    [SerializeField] private Rigidbody2D rigidBody;

    public override bool PossibleActiveForce()
    {
        if (mouseManager.IsMouseKeyDown(0) == false)
            return false;

        float absVelocityX = Math.Abs(rigidBody.linearVelocityX);
        if (absVelocityX < judgementValue)
            return true;

        return false;
    }

}
