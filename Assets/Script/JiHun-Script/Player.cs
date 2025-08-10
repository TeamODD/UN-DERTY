using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            onGroundActions?.Invoke();
    }
    public event Action onGroundActions;
}
