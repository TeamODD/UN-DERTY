using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private IPortalEvent portalEvent;
    public void AttachPortalCondition(IPortalCondition portalCondition, GameObject occurObject)
    {
        this.portalCondition = portalCondition;
        this.occurObject = occurObject;
    }
    public void DetachPortalCondition()
    {
        this.portalCondition = null;
        this.occurObject = null;
    }
    public void Update()
    {
        if (portalCondition == null)
            return;

        if (portalCondition.SatisfyCondition())
            portalEvent.OccurEvent(occurObject);
    }

    private IPortalCondition portalCondition = null;
    private GameObject occurObject = null;
}
