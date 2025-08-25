using UnityEngine;

public class TeleportActivation : IPortalActivation
{
    public TeleportActivation(PortalBase callPortal, PortalBase goToPortal)
    {
        this.callPortal = callPortal;
        this.goToPortal = goToPortal;
    }

    public void Active(ObjectBase usingObject)
    {
        usingObject.transform.position = goToPortal.transform.position;
        goToPortal.SetCooltime();
    }
    private PortalBase callPortal = null;
    private PortalBase goToPortal = null;
}

public class PortalLinker : MonoBehaviour
{
    [SerializeField] private PortalBase portal1;
    [SerializeField] private PortalBase portal2;
    private void Awake()
    {
        TeleportActivation teleportActivation1 = new TeleportActivation(portal1, portal2);
        TeleportActivation teleportActivation2 = new TeleportActivation(portal2, portal1);

        portal1.AddPortalActivation(teleportActivation1);
        portal2.AddPortalActivation(teleportActivation2);
    }
}
