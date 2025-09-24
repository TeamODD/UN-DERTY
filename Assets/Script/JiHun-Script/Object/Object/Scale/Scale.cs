using UnityEngine;

namespace jjh
{
    public class Scale : MonoBehaviour
    {
        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Ground>())
                _rigidBody.angularVelocity = 0.0f;
        }
        private Rigidbody2D _rigidBody;
    }
}
