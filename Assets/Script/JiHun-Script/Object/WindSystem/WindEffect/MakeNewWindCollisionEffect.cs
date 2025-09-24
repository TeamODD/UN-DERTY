using System;
using UnityEngine;

namespace jjh
{
    public class MakeNewWindCollisionEffect : WindCollisionEffect
    {
        [SerializeField] private float _makeWindStrength;
        [SerializeField] private float _windRemainTime = 3.0f;

        public Action<WindEntity> ActionGenerateWind;
        protected override void Start()
        {
            base.Start();
            _windGenerator = new WindGenerator(DefaultResourceLoader.Instance, DefaultObjectManager.Instance);
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

            ActionGenerateWind?.Invoke(windEntity);
        }
        private WindGenerator _windGenerator;
        private bool _bPossibleNewWind = true;


    }
}
