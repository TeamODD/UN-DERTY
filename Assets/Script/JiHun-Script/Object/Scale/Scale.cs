using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            rigidBody.angularVelocity = 0f;
        }
    }
    private Rigidbody2D rigidBody;
}
