using UnityEngine;


public class Button : MonoBehaviour
{
    [SerializeField] private IActiveCondition activeCondition;
    [SerializeField] private IButtonActivation activation;
    public void Active()
    {
        activation.Activate();
    }
    public bool IsPossibleActive()
    {
        if (activeCondition == null)
            return true;

        return activeCondition.IsPossibleActive();
    }
}
