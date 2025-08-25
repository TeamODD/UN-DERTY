using UnityEngine;

public class CollisionDPEffect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PollutionState pollutionState = GetComponent<PollutionState>();
        if (pollutionState == null)
            return;

        if (pollutionState.IsPollution() == false)
            return;

        Player player = collision.gameObject.GetComponent<Player>();
        if (player == null)
            return;

        if (bAlreadyCollision == true)
            return;

        DPmanager.Instance.AddDP(1);
        bAlreadyCollision = true;
    }
    private bool bAlreadyCollision = false;
}
