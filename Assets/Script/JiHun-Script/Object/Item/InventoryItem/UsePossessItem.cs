using UnityEngine;

public class UsePossessItem : ItemBase
{
    public UsePossessItem()
        : base(EItemType.Possessable | EItemType.Usable)
    {
    }
}
