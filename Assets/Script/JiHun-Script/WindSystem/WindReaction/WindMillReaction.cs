using UnityEngine;

public class WindMillReaction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WindEntity windEntity = collision.gameObject.GetComponent<WindEntity>();
        if (windEntity == null)
            return;

        WindMillController windMillController = collision.gameObject.GetComponent<WindMillController>();
        if(windMillController == null)
        {
            Debug.Log("WindMillController Is None");
            return;
        }
        Vector2 windDirection = windEntity.GetWindDirection();
        windMillController.GenerateWind(windDirection.x);
    }
}
