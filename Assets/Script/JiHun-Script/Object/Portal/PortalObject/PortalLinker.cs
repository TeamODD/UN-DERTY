using UnityEngine;

public class PortalLinker : MonoBehaviour
{
    [SerializeField] private TeleportPortal portal1;
    [SerializeField] private TeleportPortal portal2;
    [SerializeField] private TeleportComponent teleportComponent;
    private void Awake()
    {
        portal1.teleportComponentAction += TeleportToOtherPortal;
        portal2.teleportComponentAction += TeleportToOtherPortal;
    }
    public void TeleportToOtherPortal(GameObject gameObject, PortalBase callPortal)
    {
        if (callPortal == portal1)
            teleportComponent.Teleport(gameObject, portal2.transform.position);
        else
            teleportComponent.Teleport(gameObject, portal1.transform.position);
    }
}
