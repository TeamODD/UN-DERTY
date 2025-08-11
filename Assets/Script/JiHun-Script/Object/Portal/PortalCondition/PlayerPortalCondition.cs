using UnityEngine;

public class PlayerPortalCondition : IPortalCondition
{
    public override bool SatisfyCondition()
    {
        if (Input.GetKeyDown(KeyCode.R))
            return true;
        return false;
    }
}
