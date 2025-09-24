using System;
using UnityEngine;

namespace jjh
{
    public abstract class Button : MonoBehaviour
    {
        [SerializeField] private Plunger _plunger;
        [SerializeField] private ButtonTrigger _trigger;

        public Action ActionActivate;
        protected virtual void Start()
        {
            PollutableBase pollutableObject = GetComponent<PollutableBase>();

            _trigger.ActionCollisionEnter += ((Collision2D collision) =>
            {
                if(collision.gameObject == _plunger.gameObject)
                {
                    Activate();
                    _plunger.SetDone();
                    ActionActivate?.Invoke();
                }
            });
            _trigger.ActionCollisionExit += ((Collision2D collision) =>
            {
                if (collision.gameObject == _plunger.gameObject)
                    Deactivate();
            });
        }
        public abstract void Activate();
        public abstract void Deactivate();

    }
}
