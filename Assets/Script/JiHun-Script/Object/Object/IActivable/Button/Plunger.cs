using System;
using System.Collections.Generic;
using UnityEngine;

namespace jjh
{
    public enum EPlungerState
    {
        Default,
        Down,
        Up,
        Done,
    }
    public class Plunger : MonoBehaviour
    {
        private void Start()
        {
            _defaultPosition = transform.position;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<ButtonTrigger>() != null)
                return;
            //if(Vector3.Dot((collision.transform.position - transform.position).normalized, transform.up) > 0.2)
            _numOfEffectedObject += 1;
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<ButtonTrigger>() != null)
                return;
            //if (Vector3.Dot((collision.transform.position - transform.position).normalized, transform.up) > 0.2)
            _numOfEffectedObject -= 1;
        }
        private void Update()
        {
            // 간단하니까 그냥 상태패턴 안쓰고 switch로
            switch (PlungerState)
            {
                case EPlungerState.Default:
                    DefaultState();
                    break;
                case EPlungerState.Down:
                    DownState();
                    break;
                case EPlungerState.Up:
                    UpState();
                    break;
                case EPlungerState.Done:
                    DoneState();
                    break;
            }
        }
        private void DefaultState()
        {
            transform.position = _defaultPosition;
            if (_numOfEffectedObject > 0)
                PlungerState = EPlungerState.Down;
        }
        private void DownState()
        {
            // 애초에 꾹 눌러지는걸 전제로함.
            // 앞으로 막고 있는 경우는 한번 더 빵 쳐야함

            // 이 상태는 직접 움직이는게 아니라 물리에 따라서 움직임
            // 따라서 이 상태로 만든다는건 알아서 내려가는게 아니라 물리에 따라서 내려감
            if (_numOfEffectedObject == 0)
                PlungerState = EPlungerState.Up;
        }
        private void UpState()
        {
            if (_numOfEffectedObject > 0)
                PlungerState = EPlungerState.Down;
            else
            {
                if (TransformUtils.SmoothTickMove(transform, _defaultPosition, 2.0f))
                    PlungerState = EPlungerState.Default;
            }
        }
        private void DoneState()
        {
            if (_numOfEffectedObject == 0)
                PlungerState = EPlungerState.Up;
        }
        public void SetDone()
        {
            PlungerState = EPlungerState.Done;
        }
        public Vector3 GetDefaultPosition() { return _defaultPosition; }
        public EPlungerState PlungerState { get; private set; }

        private Vector3 _defaultPosition = Vector3.zero;
        private uint _numOfEffectedObject = 0;

    }
}