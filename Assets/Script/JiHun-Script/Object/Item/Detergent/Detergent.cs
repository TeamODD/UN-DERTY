using UnityEngine;

public class Detergent : UseItem
{
    public Detergent(int count)
        : base("Detergent", count)
    {
    }
    public override void Use()
    {
        if (DPmanager.Instance)
            DPmanager.Instance.RemoveDP(1);
    }
}
