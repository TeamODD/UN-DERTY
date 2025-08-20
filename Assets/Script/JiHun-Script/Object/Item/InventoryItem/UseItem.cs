
public abstract class UseItem : ItemBase
{
    protected UseItem(string itemName, int count)
        : base(itemName, count, EItemType.Usable)
    {
    }
}