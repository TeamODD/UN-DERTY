using UnityEngine;

public class WorldStone : WorldItem
{
    private void Awake()
    {
        successAddToInventories.Add(new AddDPSuccessAddToInventory());
    }

    public override ItemBase PickedUp(ObjectBase pickObject)
    {
        ItemCreator creator = ItemCreatorManager.Instance.GetItemCreator("Stone");
        ItemBase item = creator.CreateItem(pickObject);
        return item;
    }
}
