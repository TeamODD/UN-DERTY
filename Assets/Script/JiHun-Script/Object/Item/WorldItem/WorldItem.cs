using System;
using UnityEngine;

public interface Pickable
{
}
public abstract class WorldItem : MonoBehaviour, Pickable
{
    public abstract ItemBase PickedUp(ObjectBase pickObject);
    protected virtual void OnSuccess() { }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            ItemBase item = PickedUp(player);
            bool successAdd = player.AddItemToInventory(item);
            if (successAdd)
            {
                OnSuccess();
                Destroy(gameObject);
            }
        }
    }
}
