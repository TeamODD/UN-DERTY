using System;
using System.Collections.Generic;
using UnityEngine;

public class WindEntity : MonoBehaviour
{
    [SerializeField] private Vector2 maxVelocity;
    public Action OnDestroyed;
    public void SetWindDirection(Vector3 windDirection)
    {
        this.windDirection = windDirection.normalized;
        this.windDirection = new Vector2(this.windDirection.x, this.windDirection.y);
    }
    public void SetWindStrength(float windStrength)
    {
        this.windStrength = windStrength;
    }
    public Vector2 GetWindDirection() { return new Vector2(windDirection.x, windDirection.y); }
    public void RegistEffected(GameObject enterObject)
    {
        int instanceId = enterObject.GetInstanceID();
        Rigidbody2D rigidBody = enterObject.GetComponent<Rigidbody2D>();
        if (rigidBody == null)
            return;

        if (effectedObjects.TryGetValue(instanceId, out Rigidbody2D value) == false)
            effectedObjects.Add(instanceId, rigidBody);
    }
    public void UnRegistEffected(GameObject exitObject)
    {
        int instanceId = exitObject.GetInstanceID();

        if (effectedObjects.TryGetValue(instanceId, out Rigidbody2D value))
            effectedObjects.Remove(instanceId);
    }
    private void Update()
    {
        Vector2 force = windDirection * windStrength;
        foreach (var iter in effectedObjects)
        {
            Rigidbody2D rb = iter.Value;
            rb.AddForce(force);
            if (rb.linearVelocityX > maxVelocity.x)
                rb.linearVelocityX = maxVelocity.x;
            if (rb.linearVelocityY > maxVelocity.y)
                rb.linearVelocityY = maxVelocity.y;
        }
    }
    private void OnDestroy()
    {
        OnDestroyed?.Invoke();
    }
    // 영향을 줄 놈들
    private Dictionary<int, Rigidbody2D> effectedObjects = new Dictionary<int, Rigidbody2D>();

    private Vector2 windDirection = Vector2.zero;
    private float windStrength;
}

