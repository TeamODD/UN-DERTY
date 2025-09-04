using UnityEngine;

public class IncreaseDPButtonActivation : IButtonActivation
{
    [SerializeField] private PollutionState pollutionState;
    public override void Activate()
    {
        if (pollutionState.IsPollution() == false)
            return;

        DPmanager.Instance.AddDP(1);
    }
}
