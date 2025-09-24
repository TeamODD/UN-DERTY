using UnityEngine;

namespace jjh
{
    public class Vent : MonoBehaviour
    {
        [SerializeField] private float _coolTime;
        private void Start()
        {
            _windGenerator = new WindGenerator(DefaultResourceLoader.Instance, DefaultObjectManager.Instance);
            if (_coolTime <= 0.0f)
            {
                Debug.Log("Vent: CoolTime Check");
                return;
            }
            _timer = new Timer(_coolTime, () => _bTimeToGenerate = true);
        }
        private void Update()
        {
            if (_bTurnOn == false)
                return;

            if (_bTimeToGenerate == false)
                return;

            _windGenerator.SetWindRemainTime(_coolTime);
            _windGenerator.GenerateWind(transform.position, transform.position + transform.up * 5.0f);

            _bTimeToGenerate = false;

            // ������ ���� �����ϱ� ������ ������ �����ϸ� ������ ���Ӱ� �ð� ���É�
            _timer.SetSettingTime(_coolTime);
            _timer.ClearRemainTime();
            TimeManager.Instance.RegistOnceTimer(_timer);
        }
        public void Activate(bool turnOn)
        {
            _bTurnOn = turnOn;
            _bTimeToGenerate = turnOn;
        }

        private WindGenerator _windGenerator;
        private Timer _timer;
        private bool _bTurnOn = false;
        private bool _bTimeToGenerate = false;
    }
}
