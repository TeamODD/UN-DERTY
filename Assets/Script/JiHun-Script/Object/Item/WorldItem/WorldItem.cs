using System;
using System.Collections.Generic;
using UnityEngine;

public interface Pickable
{
}
public abstract class WorldItem : MonoBehaviour, Pickable
{
    public abstract ItemBase PickedUp(ObjectBase pickObject);
    protected virtual void OnSuccessAddToInventory() { }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            ItemBase item = PickedUp(player);
            item.SetUses(uses);
            item.SetPossess(possesss);
            item.SetUnPossesss(unpossesss);
            bool successAdd = player.AddItemToInventory(item);
            if (successAdd)
            {
                OnSuccessAddToInventory();
                Destroy(gameObject);
            }
        }
    }
    public void AddUse(IUse use)
    {
        uses.Add(use);
    }
    public void AddPossess(IPossess possess)
    {
        possesss.Add(possess);
    }
    public void AddUnPossess(IUnPossess unpossess)
    {
        unpossesss.Add(unpossess);
    }
    protected List<IUse> uses = new List<IUse>();
    protected List<IPossess> possesss = new List<IPossess>();
    protected List<IUnPossess> unpossesss = new List<IUnPossess>();
}
