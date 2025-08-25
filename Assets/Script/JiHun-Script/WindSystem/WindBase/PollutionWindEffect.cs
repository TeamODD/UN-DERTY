using UnityEngine;

public class PollutionWindEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player == null)
            return;

        DPmanager.Instance.AddDP(1);
    }
}
