using UnityEngine;

namespace jjh
{
    public class Fader
    {
        public Fader(SpriteRenderer spriteRenderer, float fadeDuration, float transparentDegree, bool bTransparent)
        {
            _spriteRenderer = spriteRenderer;
            _fadeDuration = fadeDuration;
            _fadeTimer = 0.0f;
            _transparentDegree = transparentDegree;
            _bTransparent = bTransparent;
        }
        public void Tick()
        {
            if (_fadeTimer <= 0)
                return;

            _fadeTimer -= Time.deltaTime;

            float progress = _transparentDegree;
            progress += _bTransparent ? 
                  (1 - _transparentDegree) * _fadeTimer / _fadeDuration
                : (1 - _transparentDegree) * (_fadeDuration - _fadeTimer) / _fadeDuration;

            Color currentColor = _spriteRenderer.color;

            currentColor.a = progress;

            _spriteRenderer.color = currentColor;

        }
        public void SetTransparent(bool bTransparent) { _bTransparent = bTransparent; }
        public bool IsFinish() { return _fadeTimer <= 0.0f; }
        public void ClearState()
        {
            _fadeTimer = _fadeDuration;
        }
        private SpriteRenderer _spriteRenderer;
        private float _fadeDuration;
        private float _fadeTimer;
        private float _transparentDegree;
        private bool _bTransparent;
    }
    public class RenderUtils
    {

    }
}

