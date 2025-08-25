using System.Collections.Generic;
using UnityEngine;

public abstract class ItemCreator
{
    public ItemBase CreateItem(ObjectBase ownerObject)
    {
        ItemBase item = createItem(ownerObject);
        if (item == null)
            return null;

        foreach (IUse use in uses)
            item.AddUse(use);
        foreach (IPossess possess in possesss)
            item.AddPossess(possess);
        foreach (IUnPossess unpossess in unpossesss)
            item.AddUnPossess(unpossess);

        return item;
    }
    protected abstract ItemBase createItem(ObjectBase ownerObject);
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

    protected List<IUse> uses = new List<IUse>();
    protected List<IPossess> possesss = new List<IPossess>();
    protected List<IUnPossess> unpossesss = new List<IUnPossess>();
}
