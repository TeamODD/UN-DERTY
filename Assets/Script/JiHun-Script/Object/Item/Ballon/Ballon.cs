using UnityEngine;

public class Ballon : UsePossessItem
{
    public Ballon(ObjectBase owner, int count)
        : base("Ballon", count)
    {
    }

    //public override void Possess()
    //{
    //    ownerMassManager.AddModifier(massModifier);
    //}

    //public override void UnPossess()
    //{
    //    ownerMassManager.RemoveModifier(massModifier);
    //}

    //public override void Use()
    //{
    //    Debug.Log("UseBallon");
    //    windEntityCreator.AddWindStrengthIncreaseValue(1.5f);
    //}
}
