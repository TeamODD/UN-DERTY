
public abstract class UseItem : ItemBase
{
    protected UseItem(string itemName, int count)
        : base(itemName, count, EItemType.Usable)
    {
    }
    public override void Possess() { }
    public override void UnPossess() { }
}