using UnityEngine;

namespace jjh
{
    public class IncreaseDPWindEntityEffect : IWindEntityEnterEffect
    {
        public void Effect(GameObject collsionObject)
        {
            if (collsionObject.GetComponent<Player>() == null)
                return;
            if (_bAlreadyCollisionPlayer == true)
                return;
            // Todo: dp + 1
            Debug.Log("Dp+1");
            _bAlreadyCollisionPlayer = true;
        }
        public void ClearState() { _bAlreadyCollisionPlayer = false; }
        private bool _bAlreadyCollisionPlayer = false;
    }
    public class MakeNewWindCollisionEffect : WindCollisionEffect
    {
        [SerializeField] private float _makeWindStrength;
        [SerializeField] private float _windRemainTime = 3.0f;
        protected override void Start()
        {
            base.Start();
            _windGenerator = new WindGenerator(DefaultResourceLoader.Instance, DefaultObjectManager.Instance);
            _pollutableObject = GetComponent<PollutableObject>();
            _increaseDPWindEntityEffect = new();
        }
        public override void WindCollisionEnter(WindValue windValue)
        {
            if (_bPossibleNewWind == false)
                return;

            Debug.Log("WindCollisionEnter");
            Vector3 direction = windValue.Force.x < 0.0f ? Vector3.left : Vector3.right;
            Vector3 startPosition = transform.position;
            Vector3 endPosition = startPosition + direction * _makeWindStrength;

            _bPossibleNewWind = false;

            _windGenerator.SetWindRemainTime(_windRemainTime);
            WindEntity windEntity = _windGenerator.GenerateWind(transform.position, endPosition);
            windEntity.ActionDestroy += () => _bPossibleNewWind = true;

            if (_pollutableObject.IsPollute())
            {
                _increaseDPWindEntityEffect.ClearState();
                windEntity.AddWindEntityEffect(_increaseDPWindEntityEffect);
            }
        }
        private WindGenerator _windGenerator;
        private PollutableObject _pollutableObject;

        private IncreaseDPWindEntityEffect _increaseDPWindEntityEffect;
        private bool _bPossibleNewWind = true;
    }
}
