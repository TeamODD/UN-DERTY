using System.Collections.Generic;
using UnityEngine;

public interface IMassModifier
{
    public float Modify(float baseMass);
}
public class MultiplyModifier : IMassModifier
{
    public MultiplyModifier(float multiplyMass)
    {
        this.multiplyMass = multiplyMass;
    }
    public float Modify(float baseMass)
    {
        return baseMass * multiplyMass;
    }
    private float multiplyMass;
}
public class MassManager : ObjectComponent
{
    public MassManager(ObjectBase ownerObject)
    {
        playerRigidBody = ownerObject.GetComponent<Rigidbody2D>();
        baseMass = playerRigidBody.mass;
    }
    public void SetBaseMass(float mass)
    {
        baseMass = mass;
    }
    public void AddModifier(IMassModifier modifier)
    {
        massModifiers.Add(modifier);
        CalculateMass();
    }
    public void RemoveModifier(IMassModifier modifier)
    {
        massModifiers.Remove(modifier);
        CalculateMass();
    }
    public void CalculateMass()
    {
        float finalMass = baseMass;
        foreach(IMassModifier modifier in massModifiers)
            finalMass = modifier.Modify(finalMass);
        playerRigidBody.mass = finalMass;
    }
    private Rigidbody2D playerRigidBody;
    private float baseMass;
    private List<IMassModifier> massModifiers = new List<IMassModifier>();
}
