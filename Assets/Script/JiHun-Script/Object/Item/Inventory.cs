using System;
using System.Collections.Generic;

public class ItemManager
{
    public Action<ItemManager> OnReleased;
    public ItemManager(ItemBase refItem, int maxCount)
    {
        this.refItem = refItem;
        this.maxItemCount = maxCount;
        this.currentItemCount = refItem.GetItemCount();
        copyItemName = refItem.itemName;
    }
    public bool AddItem(int count)
    {
        int sumOfCount = currentItemCount + count;
        if (sumOfCount > maxItemCount)
            return false;

        currentItemCount = sumOfCount;
        return true;
    }
    public void Use(int useCount)
    {
        if (possibleUse(useCount))
            refItem.Use();

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
    public ItemPtr(ItemManager refItemManager, int useCount)
    {
        this.refItemManager = refItemManager;
        this.useCount = useCount;
        refItemManager.OnReleased += reset;
    }
    public bool IsSame(ItemPtr other)
    {
        if(refItemManager == null || other.refItemManager == null)
            return false;

        return refItemManager == other.refItemManager && useCount == other.useCount;
    }
    public void UseItem()
    {
        if (refItemManager != null)
            refItemManager.Use(useCount);
    }
    public void ApplyPossess()
    {
        if (refItemManager != null)
            refItemManager.refItem.Possess();
    }
    public void ReleasePossess()
    {
        if (refItemManager != null)
            refItemManager.refItem.UnPossess();
    }
    private void reset(ItemManager itemManager)
    {
        refItemManager.OnReleased -= reset;
        OnItemDestroy?.Invoke(this);
        refItemManager = null;
    }

    private ItemManager refItemManager = null;
    private int useCount = 0;
}

public class Inventory : ObjectComponent
{
    public event Action<ItemBase> OnItemRegisted;   // 처음 등록될때

    private Dictionary<string, ItemManager> items = new Dictionary<string, ItemManager>();
    private ItemDataStorage dataStorage = null;

    public Inventory(ItemDataStorage dataStorage)
    {
        this.dataStorage = dataStorage;
    }
    public ItemPtr GetItemPtrOrNull(string itemName)
    {
        if (items.TryGetValue(itemName, out ItemManager manager))
        {
            if (dataStorage.FindData(itemName, out Data data))
                return new ItemPtr(manager, data.itemUseCount);
        }
        return null;
    }
    public bool AddItem(ItemBase item)
    {
        string itemName = item.itemName;

        if (items.TryGetValue(itemName, out ItemManager itemManager))
        {
            if (itemManager.AddItem(item.GetItemCount()))
                return true;
            return false; 
        }
        else
        {
            if (dataStorage.FindData(item.itemName, out Data data) == false)
                return false;

            // 새 칸을 만들고,
            itemManager = new ItemManager(item, data.itemMaxCount);
            itemManager.OnReleased += releasedItem;

            items.Add(itemName, itemManager);

            OnItemRegisted?.Invoke(item);  // 처음 등록 이벤트
        }
        return true;
    }

    private void releasedItem(ItemManager itemManager)
    {
        itemManager.OnReleased -= releasedItem;
        items.Remove(itemManager.copyItemName);
    }
}
