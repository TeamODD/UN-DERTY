using UnityEngine;

public class TeleportEvent : IPortalEvent
{
    [SerializeField] private Portal goToPortal;
    public override void OccurEvent(GameObject eventOccurObject)
    {
        Vector3 goToPosition = goToPortal.gameObject.transform.position;
        eventOccurObject.transform.position = goToPosition;
    }
}
