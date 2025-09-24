using UnityEngine;

namespace jjh
{
    public class ActiableCollisionTrigger : MonoBehaviour
    {
        private void Start()
        {
            InputManager.Instance.AddInputEvent(KeyCode.Q, EKeyState.GetKeyUp
                , (InputValue inputValue) => 
                {
                    if (_currentActivable != null)
                        _currentActivable.Activate(gameObject);
                });
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            IActivable activable = collision.GetComponent<IActivable>();
            if (activable == null)
                return;
            _currentActivable = activable;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            IActivable activable = collision.GetComponent<IActivable>();
            if (activable == null)
                return;
            if(_currentActivable == activable)
                _currentActivable = null;
        }
        private IActivable _currentActivable = null;
    }
}