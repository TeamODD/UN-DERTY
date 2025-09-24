using jjh;
using System;
using UnityEngine;

namespace jjh
{
    public class Player : MonoBehaviour
    {
        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }
        public bool IsOnGround()
        {
            return Mathf.Abs(_rigidBody.linearVelocityY) <= 1e-2;
        }
        private void Update()
        {
            
        }
        private Rigidbody2D _rigidBody;
    }
}

