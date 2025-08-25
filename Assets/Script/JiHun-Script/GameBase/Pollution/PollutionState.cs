using System;
using UnityEngine;

public class PollutionState : MonoBehaviour
{
    [SerializeField] private bool bPollution = true;
    public bool IsPollution() {  return bPollution; }
}

public class AddDPSuccessAddToInventory : ISuccessAddToInventory
{
    public void OnSuccess(WorldItem worldItem)
    {
        PollutionState pollutionState = worldItem.GetComponent<PollutionState>();
        if (pollutionState == null)
        {
            Debug.Log("AddDPSuccessAddToInventory: PollutionState Is None");
            return;
        }
        if (pollutionState.IsPollution())
            DPmanager.Instance.AddDP(1);
    }
}