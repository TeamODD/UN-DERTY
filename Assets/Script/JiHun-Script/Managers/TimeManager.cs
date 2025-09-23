using System;
using System.Collections.Generic;
using UnityEngine;

namespace jjh
{
    public class Timer
    {
        public Timer(float duration, Action onTimerEndCallback)
        {
            this._settingTime = duration;
            this._remainingTime = this._settingTime;
            this._ActionTimerEnd = onTimerEndCallback;
        }

        public void UpdateTimer(float deltaTime)
        {
            if (_remainingTime > 0)
                _remainingTime -= deltaTime;
        }

        public bool IsFinished()
        {
            return _remainingTime <= 0;
        }

        public void ClearRemainTime()
        {
            _remainingTime = _settingTime;
        }

        public void ExecuteCallback()
        {
            _ActionTimerEnd?.Invoke();
        }
        public void SetSettingTime(float time) { _settingTime = time; }

        private float _settingTime;
        private float _remainingTime;
        public Action _ActionTimerEnd;
    }

    public class TimeManager : Singleton<TimeManager>
    {
        private void Update()
        {
            ReflectAddRequest();

            foreach (Timer timer in _maintainTimers)
            {
                timer.UpdateTimer(Time.deltaTime);
                if (timer.IsFinished())
                {
                    timer.ExecuteCallback();
                    timer.ClearRemainTime();
                }
            }
            // Ȱ��ȭ�� ��� Ÿ�̸��� �ð��� ������Ʈ�ϰ�, ���� Ÿ�̸Ӵ� ���� ��⿭�� �߰��մϴ�.
            foreach (Timer timer in _onceTimers)
            {
                timer.UpdateTimer(Time.deltaTime);
                if (timer.IsFinished())
                {
                    timer.ExecuteCallback();
                    _removedOnceTimers.Enqueue(timer);
                }
            }
            ReflectRemoveRequest();
        }
        private void ReflectAddRequest()
        {
            while(_addedMaintainTimers.Count > 0)
                _maintainTimers.Add(_addedMaintainTimers.Dequeue());

            while (_addedOnceTimers.Count > 0)
                _onceTimers.Add(_addedOnceTimers.Dequeue());
        }
        private void ReflectRemoveRequest()
        {
            // ��⿭�� �ִ� Ÿ�̸ӵ��� ���� ����Ʈ���� �����ϰ� �����ϰ�, �ݹ��� �����մϴ�.
            while (_removedMaintainTimers.Count > 0)
                _maintainTimers.Remove(_removedMaintainTimers.Dequeue());
            
            while (_removedOnceTimers.Count > 0)
                _onceTimers.Remove(_removedOnceTimers.Dequeue());
        }

        public void RegistOnceTimer(Timer timer)
        {
            _addedOnceTimers.Enqueue(timer);
        }
        public void RegistMaintainTimer(Timer timer)
        {
            _addedMaintainTimers.Enqueue(timer);
        }
        public void RemoveMaintainTimer(Timer timer)
        {
            _removedMaintainTimers.Enqueue(timer);
        }

        private List<Timer> _maintainTimers = new List<Timer>();
        private List<Timer> _onceTimers = new List<Timer>();

        private Queue<Timer> _addedMaintainTimers = new();
        private Queue<Timer> _addedOnceTimers = new();

        private Queue<Timer> _removedOnceTimers = new Queue<Timer>();
        private Queue<Timer> _removedMaintainTimers = new Queue<Timer>();
    }
}