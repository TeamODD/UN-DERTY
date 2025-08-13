using UnityEngine;

public class AlwaysTrueCondition : ForceActivationConditionBase
{
    [SerializeField] private MouseManager mouseManager;
    public override bool PossibleActiveForce()
    {
        if (mouseManager.IsMouseKeyDown(0) == false)
            return false;
        return true;
    }
}
