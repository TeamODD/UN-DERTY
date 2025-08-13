using UnityEngine;

public class TestCondition : IActiveCondition
{
    public override bool IsPossibleActive()
    {
        if (Input.GetKeyDown(KeyCode.R))
            return true;
        return false;
    }
}
