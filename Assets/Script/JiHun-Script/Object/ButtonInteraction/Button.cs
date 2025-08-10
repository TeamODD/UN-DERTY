using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private IButtonDevice device;
    [SerializeField] private IActiveCondition activeCondition;
    public void Active()
    {
        if (activeCondition.IsPossibleActive() == false)
            return;
        device.ButtonInteract();
    }
}
