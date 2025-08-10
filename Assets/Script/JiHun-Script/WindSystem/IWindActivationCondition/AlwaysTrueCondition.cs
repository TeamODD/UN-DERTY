using UnityEngine;

public class AlwaysTrueCondition : IWindActivationCondition
{
    public override bool PossibleWind()
    {
        return true;
    }
}
