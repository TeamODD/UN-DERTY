using System;
using UnityEngine;

public class Player : ObjectBase
{
    public event Action onGroundActions;
    [SerializeField] private ItemDataStorage itemDataStorage;
    private void Awake()
    {
        massManager = new MassManager(this);
        inventory = new Inventory(itemDataStorage);

        AddObjectComponent(inventory);
        AddObjectComponent(massManager);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGroundActions?.Invoke();
            bOnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            bOnGround = false;
    }
    public bool AddItemToInventory(ItemBase item)
    {
        return inventory.AddItem(item);
    }
    public bool IsOnGround() { return bOnGround; }
    private bool bOnGround = false;

    private MassManager massManager;
    private Inventory inventory;
}
