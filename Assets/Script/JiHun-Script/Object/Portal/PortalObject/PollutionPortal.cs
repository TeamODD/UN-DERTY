using UnityEngine;

public class DPIncreasePortalActivation : IPortalActivation
{
    public DPIncreasePortalActivation(PortalBase portal)
    {
        pollutionState = portal.GetComponent<PollutionState>();
        if (pollutionState == null)
            Debug.Log("DPIncreasePortalActivation: PollutionState Is None");
    }
    public void Active(ObjectBase usingObject)
    {
        if (pollutionState.IsPollution())
            DPmanager.Instance.AddDP(1);
    }
    private PollutionState pollutionState = null;
}
public class PollutionPortal : MonoBehaviour
{
    private void Awake()
    {
        PortalBase portal = GetComponent<PortalBase>();
        if (portal == null)
        {
            Debug.Log("PollutionPortal: Portal Is None");
            return;
        }
        portal.AddPortalActivation(new DPIncreasePortalActivation(portal));
    }
}
