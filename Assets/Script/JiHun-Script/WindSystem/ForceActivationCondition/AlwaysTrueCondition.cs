using UnityEngine;

public class AlwaysTrueCondition : ForceActivationConditionBase
{
    public override bool PossibleActiveForce()
    {
        return true;
    }
}
