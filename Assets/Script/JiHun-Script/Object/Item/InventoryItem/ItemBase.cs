using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum EItemType
{
    Possessable = 1 << 0, // 1
    Usable = 1 << 1, // 2
}
public interface IUse
{
    public void Use(ObjectBase ownerObject);
}
public interface IPossess
{
    public void Possess(ObjectBase ownerObject);
}
public interface IUnPossess
{
    public void UnPossess(ObjectBase ownerObject);
}

public abstract class ItemBase
{
    public ItemBase(EItemType itemTypeFlag)
    {
        this.itemTypeFlag = (int)itemTypeFlag;
    }
    public void Use(ObjectBase ownerObject)
    {
        foreach (IUse use in uses)
            use.Use(ownerObject);
    }
    public void Possess(ObjectBase ownerObject)
    {
        foreach (IPossess possess in possesss)
            possess.Possess(ownerObject);
    }
    public void UnPossess(ObjectBase ownerObject)
    {
        foreach (IUnPossess unpossess in unpossesss)
            unpossess.UnPossess(ownerObject);
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
    public bool FlagCheck(EItemType type)
    {
        int typeFlag = (int)type;
        int flag = typeFlag & itemTypeFlag;
        return flag != 0;
    }

    public readonly int itemTypeFlag;

    protected List<IUse> uses = new List<IUse>();
    protected List<IPossess> possesss = new List<IPossess>();
    protected List<IUnPossess> unpossesss = new List<IUnPossess>();
}
