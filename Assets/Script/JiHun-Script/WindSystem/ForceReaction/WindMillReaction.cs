using System;
using UnityEngine;

public class WindMillReaction : IForceReaction
{
    public event Action<Vector3> windGenerateAction;
    public override void Reaction(Vector3 force)
    {
        // 여기서 바람 발생시킴
        windGenerateAction?.Invoke(force);
    }
}
