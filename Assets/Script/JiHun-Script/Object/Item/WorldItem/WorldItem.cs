using System.Collections.Generic;
using UnityEngine;

public interface ISuccessAddToInventory
{
    void OnSuccess(WorldItem worldItem);
}
public abstract class WorldItem : MonoBehaviour
{
    [SerializeField] private string itemName = "";
    [SerializeField] private int itemCount = 0;
    public abstract ItemBase PickedUp(ObjectBase pickObject);
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            Inventory inventory = player.GetObjectComponent<Inventory>();
            if (inventory == null)
                return;

            ItemBase item = PickedUp(player);
            if (item == null)
                return;

            bool successAdd = inventory.AddItem(itemName, item, itemCount);
            if (successAdd)
            {
                foreach(ISuccessAddToInventory success in successAddToInventories)
                    success.OnSuccess(this);
                Destroy(gameObject);
            }
        }
    }
    protected List<ISuccessAddToInventory> successAddToInventories = new List<ISuccessAddToInventory>();
}
