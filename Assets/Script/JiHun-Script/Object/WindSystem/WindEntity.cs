using System;
using System.Collections.Generic;
using UnityEngine;

namespace jjh
{
    public struct WindValue
    {
        public Vector2 Force { get; set; }
    }
    public interface IWindEntityEnterEffect
    {
        void Effect(GameObject collsionObject);
    }
    public class WindEntity : MonoBehaviour
    {
        [SerializeField] private float _defaultWindStrength = 3.0f;
        public Action ActionDestroy;
        private void Start()
        {
            Collider2D collider = GetComponent<Collider2D>();
            if (collider == null)
                Debug.Log("WindEntity: Collider Is None");
        }
        public void SetWindForce(Vector3 windForce)
        {
            _currentWindValue.Force = windForce * _defaultWindStrength;
        }
        public void MultiplyStrengthToForce(float strength)
        {
            _currentWindValue.Force *= strength;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject collisionObject = collision.gameObject;
            WindCollisionEffect windCollsionEffect = collisionObject.GetComponent<WindCollisionEffect>();
            if (windCollsionEffect != null)
            {
                _windCollsionEffects.Add(collisionObject.GetInstanceID(), windCollsionEffect);

                windCollsionEffect.WindCollisionEnter(_currentWindValue);

                foreach(IWindEntityEnterEffect windEntityEffect in _windEntityEffects)
                    windEntityEffect.Effect(collisionObject);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            GameObject collisionObject = collision.gameObject;
            WindCollisionEffect windCollsionEffect = collisionObject.GetComponent<WindCollisionEffect>();
            if (windCollsionEffect != null)
            {
                _windCollsionEffects.Remove(collisionObject.GetInstanceID());

                windCollsionEffect.WindCollisionExit(_currentWindValue);
            }
        }
        public void AddWindEntityEffect(IWindEntityEnterEffect windEntityEffect)
        {
            _windEntityEffects.Add(windEntityEffect);
        }
        private void FixedUpdate()
        {
            foreach (var effectPair in _windCollsionEffects)
                effectPair.Value.WindCollisionStay(_currentWindValue);
        }
        private void OnDestroy()
        {
            ActionDestroy?.Invoke();
            foreach (var effectPair in _windCollsionEffects)
                effectPair.Value.WindCollisionExit(_currentWindValue);
        }

        private Dictionary<int, WindCollisionEffect> _windCollsionEffects = new();
        private List<IWindEntityEnterEffect> _windEntityEffects = new();

        private WindValue _currentWindValue;
    }
}
