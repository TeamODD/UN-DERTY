using UnityEngine;

public class WindReaction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WindEntity windEntity = collision.gameObject.GetComponent<WindEntity>();
        if (windEntity == null)
            return;

        windEntity.RegistEffected(gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        WindEntity windEntity = collision.gameObject.GetComponent<WindEntity>();
        if (windEntity == null)
            return;

        windEntity.UnRegistEffected(gameObject);
    }
}
