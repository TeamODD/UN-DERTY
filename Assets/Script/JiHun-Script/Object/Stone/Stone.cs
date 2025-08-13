using System;
using UnityEngine;

public abstract class CasterChangeItemBase : ItemBase, ICastChange
{
    public event Action onCastChange;
    public void OnCastChange()
    {
        onCastChange?.Invoke();
    }
}
public class Stone : CasterChangeItemBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory playerInventory = collision.gameObject.GetComponent<Inventory>();
        if(playerInventory != null)
        {
            playerInventory.AddItem(this);
            this.OnCastChange();
        }
    }
}
