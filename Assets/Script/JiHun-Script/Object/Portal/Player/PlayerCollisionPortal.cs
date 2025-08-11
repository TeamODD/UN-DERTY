using UnityEngine;

public class PlayerCollisionPortal : MonoBehaviour
{
    [SerializeField] IPortalCondition portalCondition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Portal")
        {
            Portal portal = collision.gameObject.GetComponent<Portal>();
            if (portal == null)
            {
                Debug.Log("Player Collision Portal But Portal Is Null");
                return;
            }
            portal.AttachPortalCondition(portalCondition, gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            Portal portal = collision.gameObject.GetComponent<Portal>();
            if (portal == null)
            {
                Debug.Log("Player Collision Portal But Portal Is Null");
                return;
            }
            portal.DetachPortalCondition();
        }
    }
}
