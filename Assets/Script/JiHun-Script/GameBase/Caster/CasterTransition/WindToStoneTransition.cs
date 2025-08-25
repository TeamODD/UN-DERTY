using UnityEngine;

public class WindToStone : IUse
{
    public WindToStone(CasterTransition casterTransition)
    {
        this.casterTransition = casterTransition;
    }

    public void Use(ObjectBase ownerObject)
    {
        if (casterTransition != null)
            casterTransition.ChangeCaster();
    }

    private CasterTransition casterTransition = null;
}
public class WindToStoneTransition : CasterTransition
{
    private void Start()
    {
        ItemCreator stoneCreator = ItemCreatorManager.Instance.GetItemCreator("Stone");
        stoneCreator.AddUse(new WindToStone(this));
    }
}
