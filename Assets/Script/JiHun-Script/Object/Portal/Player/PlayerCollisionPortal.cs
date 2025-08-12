using UnityEngine;

public class PlayerCollisionPortal : MonoBehaviour
{
    // �Ȱ����ִٰ� ����
    private PortalBase portal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            Debug.Log("Enter");
            portal = collision.gameObject.GetComponent<PortalBase>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            Debug.Log("Exit");
            portal = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && portal)
        {
            portal.Active(gameObject);
        }
    }
}
