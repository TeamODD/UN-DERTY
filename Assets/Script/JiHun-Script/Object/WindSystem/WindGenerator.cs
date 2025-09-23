using UnityEngine;

namespace jjh
{
    public class WindGenerator
    {
        public WindGenerator(IResourceLoader resourceLoader, IObjectManager objectManager)
        {
            _objectManager = objectManager;

            windPrefab = resourceLoader.Load<WindEntity>("Prefabs/Object/Wind");
        }
        public WindEntity GenerateWind(Vector3 start, Vector3 finish)
        {
            ForceEntity forceEntity = new ForceEntity(start, finish);

            float angle = Mathf.Atan2(forceEntity.Direction.y, forceEntity.Direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            WindEntity windEntity = _objectManager.Instantiate<WindEntity>(windPrefab.gameObject, forceEntity.StartPoint, rotation);

            Vector3 offset = forceEntity.Direction * forceEntity.Distance * 0.5f;
            windEntity.transform.position += offset;
            windEntity.transform.localScale = new Vector3(forceEntity.Distance, windEntity.transform.localScale.y
                , windEntity.transform.localScale.z);

            windEntity.SetWindForce(forceEntity.ForceDiff);

            DefaultObjectManager.Instance.Destroy(windEntity.gameObject, _windRemainTime);

            return windEntity;
        }
        public void SetWindRemainTime(float time)
        {
            if (_windRemainTime > 0.0f)
                _windRemainTime = time;
        }
        private IObjectManager _objectManager = null;
        private WindEntity windPrefab = null;
        private float _windRemainTime = 0.5f;
    }
}

