using System.Collections.Generic;
using UnityEngine;

public interface IForceCommand
{
    public float Execute(float value);
}
public class MultiplyCommand : IForceCommand
{
    private readonly float multiplyValue;
    public MultiplyCommand(float multiplyValue)
    {
        this.multiplyValue = multiplyValue;
    }

    public float Execute(float value)
    {
        return value * multiplyValue;
    }
}

public class ForceStrengthController : MonoBehaviour
{
    public void ControlForce(IForceApplier forceApplier)
    {
        baseStrength = forceApplier.GetForceStrength();
        
        float finalStrength = baseStrength;
        while (commands.Count > 0)
        {
            IForceCommand command = commands.Dequeue();

            finalStrength = command.Execute(finalStrength);
        }
        
        forceApplier.SetForceStrength(finalStrength);
    }
    public void RevertStrength(IForceApplier forceApplier)
    {
        forceApplier.SetForceStrength(baseStrength);
    }
    public void AddTemporaryCommand(IForceCommand command)
    {
        commands.Enqueue(command);
    }
    private Queue<IForceCommand> commands = new Queue<IForceCommand>();
    private float baseStrength = 0.0f;
}