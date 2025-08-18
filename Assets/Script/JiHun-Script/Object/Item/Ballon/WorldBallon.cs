using UnityEngine;

public class WorldBallon : WorldItem
{
    [SerializeField] private ForceStrengthController forceStrengthController;
    private PollutionState pollutionState = null;
    private void Awake()
    {
        pollutionState = GetComponent<PollutionState>();
        if (pollutionState == null)
            Debug.Log("WorldBallon: PollutionState Is Null");
    }
    public override ItemBase PickedUp(ObjectBase pickObject)
    {
        return new Ballon(pickObject, 1, forceStrengthController);
    }
    protected override void OnSuccess()
    {
        if (pollutionState.IsPollution())
            DPmanager.Instance.AddDP(1);
    }
}
