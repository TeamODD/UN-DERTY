using UnityEngine;

public class DPIncreasePortal : TeleportPortal
{
    private PollutionState pollutionState;
    private void Awake()
    {
        pollutionState = GetComponent<PollutionState>();
        if (pollutionState == null)
            Debug.Log("DPIncreasePortal: PollutionState Is Null");
    }
    public override void Active(GameObject gameObject)
    {
        base.Active(gameObject);
        if (pollutionState.IsPollution())
            DPmanager.Instance.AddDP(1);
    }
}
