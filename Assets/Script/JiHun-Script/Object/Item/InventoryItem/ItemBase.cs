[System.Flags]
public enum EItemType
{
    Possessable = 1 << 0, // 1
    Usable = 1 << 1, // 2
}

public abstract class ItemBase
{
    public ItemBase(string itemName, int count, EItemType itemTypeFlag)
    {
        this.itemName = itemName;
        this.count = count;
        this.itemTypeFlag = (int)itemTypeFlag;
    }
    public abstract void Use();
    public abstract void Possess();
    public abstract void UnPossess();
    public int GetItemCount() { return count; }

    public bool FlagCheck(EItemType type)
    {
        int typeFlag = (int)type;
        int flag = typeFlag & itemTypeFlag;
        return flag != 0;
    }

    public readonly string itemName;
    public readonly int itemTypeFlag;

    protected int count = 0;
}
