using System;
using System.Collections.Generic;
using UnityEngine;

namespace jjh
{
    public enum MouseEventType
    {
        Down,
        Up,
        Hold
    }

    public class MouseActionData
    {
        public Action onDownActions;
        public Action onUpActions;
        public Action onHoldActions;

        public Queue<Action> releaseOnDownActions = new Queue<Action>();
        public Queue<Action> releaseOnUpActions = new Queue<Action>();
        public Queue<Action> releaseOnHoldActions = new Queue<Action>();
    }

    public class MouseManager : MonoBehaviour
    {
        private Dictionary<int, MouseActionData> mouseActions = new Dictionary<int, MouseActionData>();
        private Vector3 mousePos = Vector3.zero;

        private void Update()
        {
            foreach (var pair in mouseActions)
            {
                MouseActionData data = pair.Value;
                while (data.releaseOnDownActions.Count > 0)
                    data.onDownActions -= data.releaseOnDownActions.Dequeue();
                while (data.releaseOnUpActions.Count > 0)
                    data.onUpActions -= data.releaseOnUpActions.Dequeue();
                while (data.releaseOnHoldActions.Count > 0)
                    data.onHoldActions -= data.releaseOnHoldActions.Dequeue();
            }

            mousePos = Input.mousePosition;

            foreach (var pair in mouseActions)
            {
                int button = pair.Key;
                MouseActionData data = pair.Value;

                if (Input.GetMouseButtonDown(button))
                    data.onDownActions?.Invoke();

                if (Input.GetMouseButtonUp(button))
                    data.onUpActions?.Invoke();

                if (Input.GetMouseButton(button))
                    data.onHoldActions?.Invoke();
            }
        }

        public void RegistMouseEvent(int button, MouseEventType eventType, Action action)
        {
            if (mouseActions.ContainsKey(button) == false)
                mouseActions.Add(button, new MouseActionData());

            switch (eventType)
            {
                case MouseEventType.Down:
                    mouseActions[button].onDownActions += action;
                    break;
                case MouseEventType.Up:
                    mouseActions[button].onUpActions += action;
                    break;
                case MouseEventType.Hold:
                    mouseActions[button].onHoldActions += action;
                    break;
            }
        }

        public void UnRegistMouseEvent(int button, MouseEventType eventType, Action action)
        {
            if (mouseActions.ContainsKey(button) == false)
                return;

            switch (eventType)
            {
                case MouseEventType.Down:
                    mouseActions[button].releaseOnDownActions.Enqueue(action);
                    break;
                case MouseEventType.Up:
                    mouseActions[button].releaseOnUpActions.Enqueue(action);
                    break;
                case MouseEventType.Hold:
                    mouseActions[button].releaseOnHoldActions.Enqueue(action);
                    break;
            }
        }

        public Vector3 GetMousePosition()
        {
            return mousePos;
        }
    }
}
