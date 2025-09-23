using UnityEngine;

namespace jjh
{
    public class PortalLinker : MonoBehaviour
    {
        [SerializeField] private Portal _portal1;
        [SerializeField] private Portal _portal2;
        [SerializeField] private float _coolTime;
        private void Start()
        {
            Debug.Log($"PortalLinker: CoolTime Is {_coolTime}");

            _portal1.UseTimer(0.0f);
            _portal2.UseTimer(0.0f);

            _asyncCoolTimeTimer = new Timer(_coolTime, () =>
            {
                _portal1.SetReady(true);
                _portal2.SetReady(true);
            });

            _portal1.ActionPortalAct += SomePortalUsed;
            _portal2.ActionPortalAct += SomePortalUsed;
        }
        private void SomePortalUsed(Portal usingPortal)
        {
            _portal1.SetReady(false);
            _portal2.SetReady(false);

            _asyncCoolTimeTimer.SetSettingTime(_coolTime);
            _asyncCoolTimeTimer.ClearRemainTime();
            TimeManager.Instance.RegistOnceTimer(_asyncCoolTimeTimer);
        }

        private Timer _asyncCoolTimeTimer;
    }
}

