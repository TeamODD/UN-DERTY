using System.Collections.Generic;
using UnityEngine;


public class ItemUser : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private jjh.KeyManager keyManager;
    public void Start()
    {
        inventory = player.GetObjectComponent<Inventory>();
        inventory.OnItemRegisted += pickItem;

        for (int i = 0; i < ITEM_COUNT; i++)
            indexQueue.Enqueue(i, i);
    }
    public void UseItem(KeyCode keyCode)
    {
        itemPtrs[keyCode - KeyCode.Alpha1].UseItem(player);
    }
    private void pickItem(ItemBase item, string itemName)
    {
        if (item.FlagCheck(EItemType.Usable) == false)
            return;
        if (indexQueue.Count == 0)
            return;

        ItemPtr itemPtr = inventory.GetItemPtrOrNull(itemName);
        itemPtr.OnItemDestroy += removeItemPtr;
        
        // 원래는 상태같은거 검사해서 괜찮으면 UseItem해야함. 일단 그냥 쓰기
        int index = indexQueue.Dequeue();
        itemPtrs[index] = itemPtr;

        keyManager.RegistKeyEvent(KeyCode.Alpha1 + index, UseItem);
        
    }
    private void removeItemPtr(ItemPtr itemPtr)
    {
        int findIndex = -1;
        for (int i = 0; i < ITEM_COUNT; i++)
        {
            if (itemPtrs[i] == null)
                continue;
            if (itemPtrs[i].IsSame(itemPtr))
            {
                findIndex = i;
                break;
            }
        }
        if (findIndex != -1)
        {
            indexQueue.Enqueue(findIndex, findIndex);
            keyManager.UnRegistKeyEvent(KeyCode.Alpha1 + findIndex, UseItem);
            itemPtrs[findIndex] = null;
        }
    }
    private Inventory inventory = null;

    private const int ITEM_COUNT = 10;
    private ItemPtr[] itemPtrs = new ItemPtr[ITEM_COUNT];
    private PriorityQueue<int> indexQueue = new PriorityQueue<int>();
}
