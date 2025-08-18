using UnityEngine;

public class DPIncreaseReaction : IForceReaction
{
    public override void Reaction(Vector3 force)
    {
        DPmanager.Instance.AddDP(1);
    }
}
