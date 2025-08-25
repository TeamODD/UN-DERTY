using UnityEngine;

public class BallonCreator : ItemCreator
{
    protected override ItemBase createItem(ObjectBase ownerObject)
    {
        UsePossessItem ballon = new UsePossessItem();
        IMassModifier massModifier = new MultiplyModifier(0.5f);
        ballon.AddPossess(new PossessIncreaseMass(massModifier));
        ballon.AddUnPossess(new UnPossessIncreaseMass(massModifier));

        return ballon;
    }
}
