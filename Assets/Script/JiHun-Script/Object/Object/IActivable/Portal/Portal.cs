using System;
using UnityEngine;

namespace jjh
{
    public abstract class Portal : MonoBehaviour, IActivable
    {
        [SerializeField] private float _coolTime;
        public Action<Portal> ActionPortalAct;
        void Start()
        {
            if (_coolTime == 0.0f)
                Debug.Log($"Portal: CoolTime Is {_coolTime}");

            _coolTimeTimer = new Timer(_coolTime
                , () => SetReady(true));
        }
        public void Activate(GameObject callActivator)
        {
            if (_bReady == false)
                return;

            PortalAct(callActivator);

            if (IsUseTimer())
            {
                _coolTimeTimer.SetSettingTime(_coolTime);
                _coolTimeTimer.ClearRemainTime();
                TimeManager.Instance.RegistOnceTimer(_coolTimeTimer);
                SetReady(false);
            }
            else
                SetReady(true);

            ActionPortalAct?.Invoke(this);
        }
        public abstract void PortalAct(GameObject callActivator);
        public void SetReady(bool bReady) { _bReady = bReady; }
        public void UseTimer(float coolTime) { _coolTime = coolTime; }
        public bool IsUseTimer() { return _coolTime > 0.0f; }

        protected Timer _coolTimeTimer;
        protected bool _bReady = true;
    }
}

