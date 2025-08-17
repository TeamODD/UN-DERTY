using UnityEngine;

public class Ballon : UsePossessItem
{
    private ForceStrengthController forceStrengthController;
    public Ballon(ObjectBase owner, int count, ForceStrengthController forceStrengthController)
        : base("Ballon", count)
    {
        massModifier = new MultiplyModifier(0.5f);
        forceStrengthMultiplyCommand = new MultiplyCommand(1.5f);

        ownerMassManager = owner.GetObjectComponent<MassManager>();
        this.forceStrengthController = forceStrengthController;
    }

    public override void Possess()
    {
        ownerMassManager.AddModifier(massModifier);
    }

    public override void UnPossess()
    {
        ownerMassManager.RemoveModifier(massModifier);
    }

    public override void Use()
    {
        Debug.Log("UseBallon");
        forceStrengthController.AddTemporaryCommand(forceStrengthMultiplyCommand);
    }

    private MassManager ownerMassManager = null;
    private IMassModifier massModifier = null;
    private MultiplyCommand forceStrengthMultiplyCommand = null;


}
