using System;
using UnityEngine;

namespace jjh
{
    public class ButtonTrigger : MonoBehaviour
    {
        public Action<Collision2D> ActionCollisionEnter;
        public Action<Collision2D> ActionCollisionExit;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            ActionCollisionEnter?.Invoke(collision);
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            ActionCollisionExit?.Invoke(collision);
        }
    }
}