using System.Collections.Generic;
using System;
using UnityEngine;

namespace jjh
{
    public struct InputValue
    {
        public KeyCode keyCode;
        public EKeyState keyState;
    }

    public class InputManager : Singleton<InputManager>
    {
        public virtual void Update() 
        {
            while (_reviseQueue.Count > 0)
            {
                ReviseData reviseData = _reviseQueue.Dequeue();
                switch (reviseData.reviseType)
                {
                    case EReviseType.Add:
                        ApplyAddEvent(reviseData.keyValue, reviseData.Action);
                        break;
                    case EReviseType.Remove:
                        ApplyRemoveEvent(reviseData.keyValue, reviseData.Action);
                        break;
                }
            }
            foreach (var keyPair in _boundInputActions)
            {
                InputValue inputValue = ToInputValue(keyPair.Key);
                switch (inputValue.keyState)
                {
                    case EKeyState.GetKeyDown:
                        if (Input.GetKeyDown(inputValue.keyCode))
                            keyPair.Value?.Invoke(inputValue);
                        break;
                    case EKeyState.GetKey:
                        if (Input.GetKey(inputValue.keyCode))
                            keyPair.Value?.Invoke(inputValue);
                        break;
                    case EKeyState.GetKeyUp:
                        if (Input.GetKeyUp(inputValue.keyCode))
                            keyPair.Value?.Invoke(inputValue);
                        break;
                    default:
                        Debug.Log("InputManager: Default?");
                        break;
                }
            }
        }
        public void AddInputEvent(KeyCode key, EKeyState keyState, Action<InputValue> keyAction)
        {
            ReviseData reviseData;

            reviseData.keyValue = FromInputValue(key, keyState);
            reviseData.Action = keyAction;
            reviseData.reviseType = EReviseType.Add;

            _reviseQueue.Enqueue(reviseData);
        }
        private void ApplyAddEvent(uint keyValue, Action<InputValue> keyAction)
        {
            if (_boundInputActions.ContainsKey(keyValue))
                _boundInputActions[keyValue] += keyAction;
            else
                _boundInputActions.Add(keyValue, keyAction);
        }
        public void RemoveInputEvent(KeyCode key, EKeyState keyState, Action<InputValue> keyAction)
        {
            ReviseData reviseData;

            reviseData.keyValue = FromInputValue(key, keyState);
            reviseData.Action = keyAction;
            reviseData.reviseType = EReviseType.Remove;

            _reviseQueue.Enqueue(reviseData);
        }
        private void ApplyRemoveEvent(uint keyValue, Action<InputValue> keyAction)
        {
            if (_boundInputActions.TryGetValue(keyValue, out var action))
            {
                action -= keyAction;
                if (action == null)
                    _boundInputActions.Remove(keyValue);
                else
                    _boundInputActions[keyValue] = action;
            }
        }
        private uint FromInputValue(KeyCode key, EKeyState keyState)
        {
            return (uint)key * 100 + (uint)keyState;
        }
        private InputValue ToInputValue(uint keyValue)
        {
            InputValue keyInputValue = new InputValue();
            keyInputValue.keyCode = (KeyCode)(keyValue / 100);
            keyInputValue.keyState = (EKeyState)(keyValue % 100);
            return keyInputValue;
        }

        private Dictionary<uint, Action<InputValue>> _boundInputActions = new Dictionary<uint, Action<InputValue>>();

        public enum EReviseType : UInt16
        {
            Add,
            Remove
        }
        public struct ReviseData
        {
            public uint keyValue;
            public Action<InputValue> Action;
            public EReviseType reviseType;
        }
        private Queue<ReviseData> _reviseQueue = new();

    }
}

