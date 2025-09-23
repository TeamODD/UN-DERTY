using UnityEngine;

namespace jjh
{
    public class Scale : MonoBehaviour
    {
        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _pollutableObject = GetComponent<PollutableObject>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Ground>())
                _rigidBody.angularVelocity = 0.0f;
            
            if (collision.gameObject.GetComponent<Player>() == null)
                return;

            if (_pollutableObject.IsPollute() && _isAlreadyCollisionPlayer == false)
            {
                // Todo: ¿©±â¿¡ dp + 1
                _isAlreadyCollisionPlayer = true;
            }
        }
        private Rigidbody2D _rigidBody;
        private PollutableObject _pollutableObject;
        private bool _isAlreadyCollisionPlayer = false;
    }
}
