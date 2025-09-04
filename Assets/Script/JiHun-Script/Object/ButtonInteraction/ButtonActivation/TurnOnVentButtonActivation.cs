using UnityEngine;

public class TurnOnVentButtonActivation : IButtonActivation
{
    [SerializeField] private Vent vent;
    public override void Activate()
    {
        vent.TurnOnOff();
    }
}
