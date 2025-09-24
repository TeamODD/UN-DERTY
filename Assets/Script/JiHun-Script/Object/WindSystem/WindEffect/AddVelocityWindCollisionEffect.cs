using System;
using UnityEngine;

namespace jjh
{
    public class AddVelocityWindCollisionEffect : WindCollisionEffect
    {
        [SerializeField] private float _maxSpeed = 5.0f;

        protected override void Start()
        {
            base.Start();
            _rigidBody = GetComponent<Rigidbody2D>();
            if (_rigidBody == null)
                Debug.Log("AddForceWindEffect: RigidBody Is None");
        }
        public override void WindCollisionEnter(WindValue windValue)
        {
            _multipleValue = 0.0f;
        }
        public override void WindCollisionStay(WindValue windValue)
        {
            _multipleValue = Mathf.Lerp(_multipleValue, 1.0f, Time.deltaTime);
            _rigidBody.linearVelocity += windValue.Force * _multipleValue;
        }
        private void FixedUpdate()
        {
            // 만약 이미 최대 속도를 초과했다면, 속도를 제한합니다.
            if (_rigidBody.linearVelocity.magnitude > _maxSpeed)
                _rigidBody.linearVelocity = _rigidBody.linearVelocity.normalized * _maxSpeed;

        }
        protected Rigidbody2D _rigidBody = null;
        private float _multipleValue = 0.0f;
    }
}

