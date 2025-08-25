using System.Collections.Generic;
using UnityEngine;

public interface IPortalActivation
{
    void Active(ObjectBase usingObject);
}

public class PortalBase : MonoBehaviour
{
    [SerializeField] private float reActivationTime = 0.0f;
    public void Active(ObjectBase usingObject)
    {
        if (bAlreadyActive == true)
            return;

        foreach (IPortalActivation portalActivation in portalActivations)
            portalActivation.Active(usingObject);

        SetCooltime();
    }
    public void SetCooltime()
    {
        bAlreadyActive = true;
        currentTime = reActivationTime;
    }
    public void AddPortalActivation(IPortalActivation portalActivation)
    {
        portalActivations.Add(portalActivation);
    }
    private void Update()
    {
        if (bAlreadyActive == false)
            return;

        if(0.0f < currentTime)
            currentTime -= Time.deltaTime;

        if (currentTime <= 0.0f)
            bAlreadyActive = false;
    }

    private List<IPortalActivation> portalActivations = new List<IPortalActivation>();
    private float currentTime = 0.0f;
    private bool bAlreadyActive = false;
}
