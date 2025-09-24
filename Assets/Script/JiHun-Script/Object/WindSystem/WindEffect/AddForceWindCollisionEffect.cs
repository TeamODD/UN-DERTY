using UnityEngine;

namespace jjh
{
    public class AddForceWindCollisionEffect : WindCollisionEffect
    {
        [SerializeField] private float _maxSpeed = 5.0f;

        protected override void Start()
        {
            base.Start();
            _rigidBody = GetComponent<Rigidbody2D>();
            if (_rigidBody == null)
            {
                Debug.Log("AddForceWindEffect: RigidBody Is None");
                return;
            }
            _defaultGravity = _rigidBody.gravityScale;
            _defaultDamping = _rigidBody.linearDamping;
        }
        public override void WindCollisionEnter(WindValue windValue)
        {
            _rigidBody.gravityScale = 0.0f;
            _rigidBody.linearDamping = 0.0f;
        }
        public override void WindCollisionExit(WindValue windValue)
        {
            // 일단 하드코딩
            _rigidBody.gravityScale = _defaultGravity;
            _rigidBody.linearDamping = _defaultDamping;
        }
        public override void WindCollisionStay(WindValue windValue)
        {
            _rigidBody.AddForce(windValue.Force);
        }
        private void FixedUpdate()
        {
            // 만약 이미 최대 속도를 초과했다면, 속도를 제한합니다.
            if (_rigidBody.linearVelocity.magnitude > _maxSpeed)
                _rigidBody.linearVelocity = _rigidBody.linearVelocity.normalized * _maxSpeed;

        }
        protected Rigidbody2D _rigidBody = null;
        private float _defaultGravity = 0.0f;
        private float _defaultDamping = 0.0f;
    }
}
