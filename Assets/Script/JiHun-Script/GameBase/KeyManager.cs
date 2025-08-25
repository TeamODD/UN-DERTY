using System;
using System.Collections.Generic;
using UnityEngine;

namespace jjh
{
    public class KeyActionData
    {
        public KeyActionData(Action<KeyCode> actions)
        {
            this.actions = actions;
        }
        public Action<KeyCode> actions;
        public Queue<Action<KeyCode>> releaseActions = new Queue<Action<KeyCode>>();
    }
    public class KeyManager : MonoBehaviour
    {
        private void Update()
        {
            // ���� �������� �͵� �����
            foreach (var pair in keyActions)
            {
                KeyActionData data = pair.Value;
                if (data.releaseActions.Count == 0)
                    continue;
                while (data.releaseActions.Count > 0)
                {
                    Action<KeyCode> action = data.releaseActions.Dequeue();
                    data.actions -= action;
                }
            }
            // �״��� ���� �׼� ����
            foreach (var pair in keyActions)
            {
                if (Input.GetKeyDown(pair.Key))
                {
                    pair.Value.actions?.Invoke(pair.Key);
                }
            }
        }
        public void RegistKeyEvent(KeyCode key, Action<KeyCode> action)
        {
            if (keyActions.ContainsKey(key))
            {
                keyActions[key].actions += action;
            }
            else
            {
                keyActions.Add(key, new KeyActionData(action));

            }
        }
        public void UnRegistKeyEvent(KeyCode key, Action<KeyCode> action)
        {
            if (keyActions.ContainsKey(key))
            {
                keyActions[key].releaseActions.Enqueue(action);
            }
        }
        private Dictionary<KeyCode, KeyActionData> keyActions = new Dictionary<KeyCode, KeyActionData>();
    }
}

