using UnityEngine;

namespace jjh
{
    [System.Serializable]
    public struct CastData
    {
        public string castName;
        public SystemCastBase systemCast;
    }
    public class SystemCaster : MonoBehaviour
    {
        [SerializeField] private CastData[] _castDatas;
        private SystemCastBase _currentSystemCast;
        private void Start()
        {
            if(_castDatas.Length == 0)
            {
                Debug.Log("SystemCaster: CastData Is Empty");
                return;
            }
            _currentSystemCast = _castDatas[0].systemCast;
            InitalizeCast();
        }
        public void InitalizeCast()
        {
            InputManager.Instance.AddInputEvent(KeyCode.Mouse0, EKeyState.GetKeyDown
                , Cast);
        }
        public void ReleaseCast()
        {
            InputManager.Instance.RemoveInputEvent(KeyCode.Mouse0, EKeyState.GetKeyDown
                , Cast);
        }
        private void Cast(InputValue inputValue)
        {
            _currentSystemCast.Cast(gameObject);
        }
        public SystemCastBase GetSystemCast(string castName)
        {
            foreach (var castData in _castDatas)
            {
                if (castData.castName.Equals(castName))
                    return castData.systemCast;
            }
            Debug.Log("SystemCaster: GetSystemCast Is Failed");
            return null;
        }
        public SystemCastBase SetCurrentCast(string castName)
        {
            foreach(var castData in _castDatas)
            {
                if(castData.castName.Equals(castName))
                {
                    ReleaseCast();
                    _currentSystemCast = castData.systemCast;
                    InitalizeCast();
                    return _currentSystemCast;
                }
            }
            Debug.Log("SystemCaster: SetCurrentCast Is Failed");
            return null;
        }
        public bool IsCurrentCast(string castName)
        {
            return _currentSystemCast == GetSystemCast(castName);
        }
    }
}

