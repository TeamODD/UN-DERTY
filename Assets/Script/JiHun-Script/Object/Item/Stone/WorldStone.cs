using UnityEngine;

public class WorldStone : WorldItem
{
    [SerializeField] protected GameObject returnObject;
    [SerializeField] private CasterManager manager;
    [SerializeField] private StoneCaster stoneCaster;
    public override ItemBase PickedUp(ObjectBase pickObject)
    {
        Stone stone = new Stone(pickObject, 1, manager, stoneCaster);
        IMassModifier modifier = stone.GetModifier();

        stoneCaster.SetModifier(modifier);

        return stone;
    }
}
