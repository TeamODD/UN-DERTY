using UnityEngine;

namespace jjh
{
    public class Lift : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _target;
        private void Start()
        {
            _initialPosition = transform.position;
        }
        private void Update()
        {
            if (_bMove == false)
                return;

            if(_bTo && _bBack == false)
            {
                if (TransformUtils.SmoothTickMove(transform, _target.transform.position, _speed) == true)
                    _bMove = false;
            }
            else if(_bTo == false && _bBack)
            {
                if (TransformUtils.SmoothTickMove(transform, _initialPosition, _speed) == true) 
                    _bMove = false;
            }
            else
                Debug.Log("Lift: Update Warning");
        }
        public void MoveTo()
        {
            _bMove = true;
            _bTo = true;
            _bBack = false;
        }
        public void MoveBack()
        {
            _bMove = true;
            _bTo = false;
            _bBack = true;
        }
        private bool _bMove = false;

        private bool _bTo = false;
        private bool _bBack = false;
        private Vector3 _initialPosition;
    }
}
