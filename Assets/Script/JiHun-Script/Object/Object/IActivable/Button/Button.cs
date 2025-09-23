using System;
using UnityEngine;

namespace jjh
{
    public abstract class Button : MonoBehaviour
    {
        [SerializeField] private Plunger _plunger;
        [SerializeField] private ButtonTrigger _trigger;
        protected virtual void Start()
        {
            _pollutableObject = GetComponent<PollutableObject>();

            _trigger.ActionCollisionEnter += ((Collision2D collision) =>
            {
                if(collision.gameObject == _plunger.gameObject)
                {
                    Activate();
                    _plunger.SetDone();
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

        private PollutableObject _pollutableObject;

    }
}
