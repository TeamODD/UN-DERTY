using UnityEngine;

public class CollisionDPEffect : MonoBehaviour
{
    private PollutionState pollutionState;
    private void Awake()
    {
        pollutionState = GetComponent<PollutionState>();
        if (pollutionState == null)
            Debug.Log("PollutionState Is Null");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pollutionState.IsPollution() == false)
            return;

        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            DPmanager.Instance.AddDP(1);
        }
    }
}
