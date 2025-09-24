using System.Collections.Generic;
using UnityEngine;

namespace jjh
{
    public class WindCast : SystemCastBase
    {
        [SerializeField] private Player _player;
        public void Start()
        {
            _windGen = new WindGenerator(DefaultResourceLoader.Instance, DefaultObjectManager.Instance);
        }
        public override void Cast(GameObject casterObject)
        {
            if (_player.IsOnGround() == false)
                return;
            
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0.0f;

            WindEntity generatedWindEntity = _windGen.GenerateWind(_player.transform.position, mousePosition);
            float multiplyStrengthValue = 1.0f;
            while(_aditionalStrengthQueue.Count > 0)
            {
                Debug.Log("AddStrength");
                multiplyStrengthValue *= _aditionalStrengthQueue.Dequeue();
            }

            generatedWindEntity.MultiplyStrengthToForce(multiplyStrengthValue);
        }
        public void AddMultiplyStrengthValue(float value)
        {
            _aditionalStrengthQueue.Enqueue(value);
        }
        private WindGenerator _windGen;
        private Queue<float> _aditionalStrengthQueue = new();
    }
}
