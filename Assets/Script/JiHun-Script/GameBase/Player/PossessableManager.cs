using System.Collections.Generic;
using UnityEngine;

// ������ ������ �ٷ� ����ȿ�� �����Ű�� Ŭ����
public class PossessableManager : MonoBehaviour
{
    [SerializeField] private Player player;
    private void Start()
    {
        inventory = player.GetObjectComponent<Inventory>();
        inventory.OnItemRegisted += pickPossessItem;
    }
    private void pickPossessItem(ItemBase item, string itemName)
    {
        if (item.FlagCheck(EItemType.Possessable) == false)
            return;

        ItemPtr itemPtr = inventory.GetItemPtrOrNull(itemName);
        if (itemPtr == null) 
            return;

        itemPtr.ApplyPossess(player);
        itemPtr.OnItemDestroy += removePossessItem;
        itemPtrs.Add(itemPtr);
    }
    private void removePossessItem(ItemPtr itemPtr)
    {
        itemPtr.ReleasePossess(player);
        itemPtr.OnItemDestroy -= removePossessItem;
        itemPtrs.Remove(itemPtr);
    }
    private Inventory inventory = null;

    private List<ItemPtr> itemPtrs = new List<ItemPtr>();
}
