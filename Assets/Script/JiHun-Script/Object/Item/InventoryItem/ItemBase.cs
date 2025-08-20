using System.Collections.Generic;

[System.Flags]
public enum EItemType
{
    Possessable = 1 << 0, // 1
    Usable = 1 << 1, // 2
}

public interface IUse
{
    public void Use();
}
public interface IPossess
{
    public void Possess();
}
public interface IUnPossess
{
    public void UnPossess();
}

public abstract class ItemBase
{
    public ItemBase(string itemName, int count, EItemType itemTypeFlag)
    {
        this.itemName = itemName;
        this.count = count;
        this.itemTypeFlag = (int)itemTypeFlag;
    }
    public void Use()
    {
        foreach (IUse use in uses)
            use.Use();
    }
    public void Possess()
    {
        foreach (IPossess possess in possesss)
            possess.Possess();
    }
    public void UnPossess()
    {
        foreach (IUnPossess unpossess in unpossesss)
            unpossess.UnPossess();
    }
    public int GetItemCount() { return count; }

    public bool FlagCheck(EItemType type)
    {
        int typeFlag = (int)type;
        int flag = typeFlag & itemTypeFlag;
        return flag != 0;
    }
    public void AddUse(IUse use)
    {
        uses.Add(use);
    }
    public void AddPossess(IPossess possess)
    {
        possesss.Add(possess);
    }
    public void AddUnPossess(IUnPossess unpossess)
    {
        unpossesss.Add(unpossess);
    }
    public void SetUses(List<IUse> uses)
    { this.uses = uses; }
    public void SetPossess(List<IPossess> possesss)
    { this.possesss = possesss; }
    public void SetUnPossesss(List<IUnPossess> unpossesss)
    { this.unpossesss = unpossesss; }

    public readonly string itemName;
    public readonly int itemTypeFlag;

    protected int count = 0;
    protected List<IUse> uses = new List<IUse>();
    protected List<IPossess> possesss = new List<IPossess>();
    protected List<IUnPossess> unpossesss = new List<IUnPossess>();
}
