using UnityEngine;

public abstract class PossessItem : ItemBase
{
    public PossessItem(string itemName, int count)
        : base(itemName, count, EItemType.Possessable)
    {
    }
}