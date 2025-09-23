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
            // �����ϴϱ� �׳� �������� �Ⱦ��� switch��
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
            // ���ʿ� �� �������°� ��������.
            // ������ ���� �ִ� ���� �ѹ� �� �� �ľ���

            // �� ���´� ���� �����̴°� �ƴ϶� ������ ���� ������
            // ���� �� ���·� ����ٴ°� �˾Ƽ� �������°� �ƴ϶� ������ ���� ������
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