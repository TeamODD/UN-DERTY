using UnityEngine;

namespace jjh
{
    public class Box : MonoBehaviour
    {
        private void Start()
        {
            _pollutableObject = GetComponent<PollutableObject>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Player>() == null)
                return;

            if (_pollutableObject.IsPollute() && _isAlreadyCollisionPlayer == false)
            {
                // Todo: ¿©±â¿¡ dp + 1
                _isAlreadyCollisionPlayer = true;
            }

        }
        private PollutableObject _pollutableObject = null;
        private bool _isAlreadyCollisionPlayer = false;
    }
}