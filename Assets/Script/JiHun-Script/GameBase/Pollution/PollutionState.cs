using System;
using UnityEngine;

public class PollutionState : MonoBehaviour
{
    [SerializeField] private bool bPollution = true;
    public event Action<bool> OnSetPollutionState;
    public void SetPollutionState(bool bPollution)
    {
        this.bPollution = bPollution;
        OnSetPollutionState?.Invoke(this.bPollution);
    }
    public bool IsPollution() {  return bPollution; }
}
