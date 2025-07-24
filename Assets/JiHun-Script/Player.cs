using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            bOnGround = true;
        }
            
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            bOnGround = false;
        }
    }
    public bool IsOnGround() { return bOnGround; }
    private bool bOnGround = false;
}
