using UnityEngine;

public class PlayerCollisionPortal : MonoBehaviour
{
    // 안겹쳐있다고 가정
    private void Awake()
    {
        player = GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PortalBase p = collision.gameObject.GetComponent<PortalBase>();
        if (p != null)
            portal = p;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PortalBase p = collision.gameObject.GetComponent<PortalBase>();
        if (p != null)
            portal = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && portal)
            portal.Active(player);
    }
    private Player player;
    private PortalBase portal;
}
