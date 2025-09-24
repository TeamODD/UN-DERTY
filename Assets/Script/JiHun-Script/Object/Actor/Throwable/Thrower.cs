using UnityEngine;

namespace jjh
{
    public interface IThrow
    {
        void Throw(Vector2 velocity);
    }

    // 원래는 각자 인풋을 정하도록 추상화해야되지만 그냥 플레이어만 대상으로 하자
    public class Thrower : MonoBehaviour, IThrow
    {
        [SerializeField] private ThrowableObject _throwableObjectPrefab;
        private void Start()
        {
            if (_throwableObjectPrefab == null)
                Debug.Log("ThrowCaster: ThrowableObject Is None");
        }
        public void Throw(Vector2 velocity)
        {
            // 플레이어만 상정하고 던지는 기능 구현
            GameObject throwObject = Instantiate(_throwableObjectPrefab.gameObject, gameObject.transform);
            throwObject.GetComponent<Rigidbody2D>().linearVelocity = velocity;
        }
    }
}
