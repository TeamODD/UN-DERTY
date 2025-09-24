using UnityEngine;

namespace jjh
{
    public abstract class WindCollisionEffect : MonoBehaviour
    {
        protected virtual void Start()
        {
            Collider2D collider = GetComponent<Collider2D>();
            if (collider == null)
                Debug.Log("AddForceWindEffect: Collider Is None");
        }
        public virtual void WindCollisionEnter(WindValue windValue) { }
        public virtual void WindCollisionStay(WindValue windValue) { }
        public virtual void WindCollisionExit(WindValue windValue) { }
    }
}
