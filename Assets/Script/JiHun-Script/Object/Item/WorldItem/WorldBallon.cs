using UnityEngine;

public class WorldBallon : WorldItem
{
    private void Awake()
    {
        successAddToInventories.Add(new AddDPSuccessAddToInventory());
    }
    public override ItemBase PickedUp(ObjectBase pickObject)
    {
        ItemCreator creator = ItemCreatorManager.Instance.GetItemCreator("Ballon");
        ItemBase item = creator.CreateItem(pickObject);
        return item;
    }
}
