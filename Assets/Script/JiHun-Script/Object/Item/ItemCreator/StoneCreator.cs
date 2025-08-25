using UnityEngine;

public class PossessIncreaseMass : IPossess
{
    public PossessIncreaseMass(IMassModifier massModifier)
    {
        this.massModifier = massModifier;
    }
    public void Possess(ObjectBase ownerObject)
    {
        MassManager massManager = ownerObject.GetObjectComponent<MassManager>();
        massManager.AddModifier(massModifier);
    }
    private IMassModifier massModifier;
}

public class UnPossessIncreaseMass : IUnPossess
{
    public UnPossessIncreaseMass(IMassModifier massModifier)
    {
        this.massModifier = massModifier;
    }
    public void UnPossess(ObjectBase ownerObject)
    {
        MassManager massManager = ownerObject.GetObjectComponent<MassManager>();
        massManager.RemoveModifier(massModifier);
    }
    private IMassModifier massModifier;
}

public class StoneCreator : ItemCreator
{
    protected override ItemBase createItem(ObjectBase ownerObject)
    {
        UsePossessItem stone = new UsePossessItem();
        return stone;
    }
}
