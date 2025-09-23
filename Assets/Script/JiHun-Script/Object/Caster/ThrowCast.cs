using UnityEngine;

namespace jjh
{
    public class ThrowCast : SystemCastBase
    {
        [SerializeField] private Thrower _thrower;
        public override void Cast(GameObject casterObject)
        {
            // ���࿡ Thrower�� ���������...?
            if (_thrower == null)
                return;

            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0.0f;

            ForceEntity forceEntity = new ForceEntity(_thrower.transform.position, mousePosition);

            _thrower.Throw(new Vector2(forceEntity.ForceDiff.x, forceEntity.ForceDiff.y));
            ActionSuccessCast?.Invoke(this);
        }
    }
}