using JetBrains.Annotations;
using System;
using UnityEngine;

public interface IJudgeWind
{
    public abstract bool PossibleWind();
}

public class JudgeByVelocity : IJudgeWind
{
    public JudgeByVelocity(Player player, float judgementValue)
    {
        this.player = player;
        rigidBody = player.GetComponent<Rigidbody2D>();
        this.judgementValue = judgementValue;
    }

    public bool PossibleWind()
    {
        if (player.IsOnGround() == false)
            return false;

        float absVelocityX = Math.Abs(rigidBody.linearVelocityX);
        if (absVelocityX < judgementValue)
            return true;

        return false;
    }

    private Player player = null;
    private Rigidbody2D rigidBody = null;
    private float judgementValue = 0.0f;

}
