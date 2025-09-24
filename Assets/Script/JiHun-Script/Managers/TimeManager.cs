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
            // 활성화된 모든 타이머의 시간을 업데이트하고, 끝난 타이머는 제거 대기열에 추가합니다.
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
            // 대기열에 있는 타이머들을 실제 리스트에서 안전하게 제거하고, 콜백을 실행합니다.
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