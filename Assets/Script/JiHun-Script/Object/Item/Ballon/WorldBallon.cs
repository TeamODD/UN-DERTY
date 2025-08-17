using UnityEngine;

public class WorldBallon : WorldItem
{
    [SerializeField] private ForceStrengthController forceStrengthController;
    public override ItemBase PickedUp(ObjectBase pickObject)
    {
        return new Ballon(pickObject, 1, forceStrengthController);
    }
}
