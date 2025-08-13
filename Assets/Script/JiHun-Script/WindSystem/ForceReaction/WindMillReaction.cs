using System;
using UnityEngine;

public class WindMillReaction : IForceReaction
{
    public event Action<Vector3> windGenerateAction;
    public override void Reaction(Vector3 force)
    {
        // ���⼭ �ٶ� �߻���Ŵ
        windGenerateAction?.Invoke(force);
    }
}
