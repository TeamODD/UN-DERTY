using UnityEngine;

public abstract class UsePossessItem : ItemBase
{
    public UsePossessItem(string itemName, int count) 
        : base(itemName, count, EItemType.Possessable | EItemType.Usable)
    {
    }
}
