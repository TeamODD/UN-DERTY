using System;
using UnityEngine;

namespace jjh
{
    [Serializable]
    public enum EBarrierType : UInt16
    {
        Appear,
        Disapper,
    }
    public class Barrier : MonoBehaviour
    {
        [SerializeField] private EBarrierType _barrierType;
        [SerializeField] private float _transformTime = 2.0f;
        [SerializeField] private float _minAlpha = 0.0f;
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
            if (_barrierType == EBarrierType.Appear)
            {
                _collider.enabled = false;
                _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _minAlpha);
            }

            _fader = new Fader(_spriteRenderer, _transformTime, _minAlpha, true);
        }
        public void SetActive(bool active)
        {
            bool transparent = false;
            switch (_barrierType)
            {
                case EBarrierType.Appear:
                    transparent = active ? false : true;
                    break;
                case EBarrierType.Disapper:
                    transparent = active ? true : false;
                    break;
            }

            if (_collider != null)
                _collider.enabled = !transparent;

            _fader.SetTransparent(transparent);
            _fader.ClearState();
        }
        
        private void Update()
        {
            if (_fader.IsFinish())
                return;
            _fader.Tick();
        }
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider;
        private Fader _fader;
    }
}
