using UnityEngine;

public abstract class PossessItem : ItemBase
{
    public PossessItem()
        : base(EItemType.Possessable)
    {
    }
}