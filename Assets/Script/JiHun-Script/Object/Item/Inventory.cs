using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler
{
    public Action<ItemHandler> OnReleased;
    public ItemHandler(ItemBase refItem, string itemName, int count, int maxCount)
    {
        this.refItem = refItem;
        this.maxItemCount = maxCount;
        this.currentItemCount = count;
        copyItemName = itemName;
    }
    public bool AddItem(int count)
    {
        int sumOfCount = currentItemCount + count;
        if (sumOfCount > maxItemCount)
            return false;

        currentItemCount = sumOfCount;
        return true;
    }
    public void Use(ObjectBase ownerObject, int useCount)
    {
        if (possibleUse(useCount))
            refItem.Use(ownerObject);

        if (currentItemCount == 0)
            OnReleased?.Invoke(this);
    }
    private bool possibleUse(int useCount)
    {
        if (currentItemCount < useCount)
            return false;

        currentItemCount -= useCount;
        return true;
    }
    public readonly ItemBase refItem;
    public readonly string copyItemName;
    public readonly int maxItemCount;

    private int currentItemCount;
}

public class ItemPtr
{
    public Action<ItemPtr> OnItemDestroy;
    public ItemPtr(ItemHandler refItemManager, int useCount)
    {
        this.refItemHandler = refItemManager;
        this.useCount = useCount;
        refItemManager.OnReleased += reset;
    }
    public bool IsSame(ItemPtr other)
    {
        if(refItemHandler == null || other.refItemHandler == null)
            return false;

        return refItemHandler == other.refItemHandler && useCount == other.useCount;
    }
    public void UseItem(ObjectBase ownerObject)
    {
        if (refItemHandler != null)
            refItemHandler.Use(ownerObject, useCount);
    }
    public void ApplyPossess(ObjectBase ownerObject)
    {
        if (refItemHandler != null)
            refItemHandler.refItem.Possess(ownerObject);
    }
    public void ReleasePossess(ObjectBase ownerObject)
    {
        if (refItemHandler != null)
            refItemHandler.refItem.UnPossess(ownerObject);
    }
    private void reset(ItemHandler itemManager)
    {
        refItemHandler.OnReleased -= reset;
        OnItemDestroy?.Invoke(this);
        refItemHandler = null;
    }

    private ItemHandler refItemHandler = null;
    private int useCount = 0;
}

public class Inventory : ObjectComponent
{
    public event Action<ItemBase, string> OnItemRegisted;   // 처음 등록될때

    private Dictionary<string, ItemHandler> items = new Dictionary<string, ItemHandler>();
    private ItemDataStorage dataStorage = null;

    public Inventory(ItemDataStorage dataStorage)
    {
        this.dataStorage = dataStorage;
    }
    public ItemPtr GetItemPtrOrNull(string itemName)
    {
        if (items.TryGetValue(itemName, out ItemHandler manager))
        {
            if (dataStorage.FindData(itemName, out Data data))
                return new ItemPtr(manager, data.itemUseCount);
        }
        return null;
    }
    public bool AddItem(string itemName, ItemBase item, int count)
    {
        if (items.TryGetValue(itemName, out ItemHandler itemHandler))
        {
            if (itemHandler.AddItem(count))
                return true;
            return false; 
        }
        else
        {
            if (dataStorage.FindData(itemName, out Data data) == false)
                return false;

            // 새 칸을 만들고,
            itemHandler = new ItemHandler(item, itemName, count, data.itemMaxCount);
            itemHandler.OnReleased += releasedItem;

            items.Add(itemName, itemHandler);

            OnItemRegisted?.Invoke(item, itemName);  // 처음 등록 이벤트
        }
        return true;
    }

    private void releasedItem(ItemHandler itemManager)
    {
        itemManager.OnReleased -= releasedItem;
        items.Remove(itemManager.copyItemName);
    }
}
