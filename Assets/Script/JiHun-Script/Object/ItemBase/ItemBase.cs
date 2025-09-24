namespace jjh
{
    public abstract class ItemBase
    {
        public ItemBase(string itemName)
        {
            ItemName = itemName;
        }
        public string ItemName { get; private set; }
    }
}

