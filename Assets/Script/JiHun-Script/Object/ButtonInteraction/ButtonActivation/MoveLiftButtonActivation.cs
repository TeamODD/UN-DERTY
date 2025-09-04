using UnityEngine;

public class MoveLiftButtonActivation : IButtonActivation
{
    [SerializeField] private Lift lift;
    public override void Activate()
    {
        lift.MoveLift();
    }
}
