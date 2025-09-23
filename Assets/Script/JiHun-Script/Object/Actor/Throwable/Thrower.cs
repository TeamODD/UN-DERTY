using UnityEngine;

namespace jjh
{
    public interface IThrow
    {
        void Throw(Vector2 velocity);
    }

    // ������ ���� ��ǲ�� ���ϵ��� �߻�ȭ�ؾߵ����� �׳� �÷��̾ ������� ����
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
            // �÷��̾ �����ϰ� ������ ��� ����
            GameObject throwObject = Instantiate(_throwableObjectPrefab.gameObject, gameObject.transform);
            throwObject.GetComponent<Rigidbody2D>().linearVelocity = velocity;
        }
    }
}
