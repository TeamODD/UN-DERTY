using System;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ForceEntity
{
    public ForceEntity(Vector3 start, Vector3 finish)
    {
        forceStartPoint = start;
        forceFinishPoint = finish;
        forceDirection = (finish - start).normalized;
    }

    public Vector3 StartPoint => forceStartPoint;
    public Vector3 FinishPoint => forceFinishPoint;
    public Vector3 Direction => forceDirection;
    public float Distance => Vector3.Distance(forceStartPoint, forceFinishPoint);

    private Vector3 forceStartPoint;
    private Vector3 forceFinishPoint;
    private Vector3 forceDirection;
}

public class ForceReaction
{
    public ForceReaction(GameObject refObject, List<Action> actions)
    {
        this.refObject = refObject;
        rigidbody = refObject.GetComponent<Rigidbody2D>();
        this.actions = actions;
    }
    public void Reaction(Vector3 strength)
    {
        rigidbody.AddForce(strength, ForceMode2D.Force);
        if (actions == null)
            return;
        for (int i = 0; i < actions.Count; i++)
        {
            Action action = actions[i];
            action.Invoke();
        }
    }

    private GameObject refObject = null;
    private Rigidbody2D rigidbody = null;
    private List<Action> actions = null;
}

public class ForceReactionStorage
{
    public ForceReactionStorage()
    {
        applyForceObjects = new Dictionary<int, ForceReaction>();
    }
    public void RegistApplyObject(GameObject applyObject, List<Action> actions)
    {
        int id = applyObject.GetInstanceID();
        applyForceObjects.Add(id, new ForceReaction(applyObject, actions));
    }
    public void RemoveApplyObject(GameObject applyObject)
    {
        int id = applyObject.GetInstanceID();
        applyForceObjects.Remove(id);
    }

    public ForceReaction IsRegisted(GameObject gameObject)
    {
        int id = gameObject.GetInstanceID();
        ForceReaction forceReaction = applyForceObjects[id];

        return forceReaction;
    }

    public int StorageCount() { return applyForceObjects.Count; }
    private Dictionary<int, ForceReaction> applyForceObjects = null;
}

public class ApplyForce
{
    public ApplyForce(float forceStrength, float maxStrength, float coefficient)
    {
        this.forceStrength = forceStrength;
        this.maxStrength = maxStrength;
        this.coefficient = coefficient;
    }
    public void Apply(ForceEntity forceEntity, ForceReactionStorage objectStorage)
    {
        Vector2 rayStartPoint = new Vector2(forceEntity.StartPoint.x, forceEntity.StartPoint.y);
        Vector2 rayDirection = new Vector2(forceEntity.Direction.x, forceEntity.Direction.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(rayStartPoint, rayDirection, forceEntity.Distance);

        foreach (RaycastHit2D hit in hits)
        {
            GameObject obj = hit.collider.gameObject;

            ForceReaction forceReaction = objectStorage.IsRegisted(obj);

            if (forceReaction == null)
                continue;

            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb == null)
                continue;
            
            Vector2 objPosition = obj.transform.position;

            float strength = forceStrength * coefficient * forceEntity.Distance;
            if (strength > maxStrength)
                strength = maxStrength;
            
            Vector3 force = forceEntity.Direction * strength;

            forceReaction.Reaction(force);
        }
    }

    private float forceStrength;
    private float coefficient;
    private float maxStrength;
}

public abstract class IGenerateForce
{
    public abstract ForceEntity Generate();
}

public class ForceGenerator_Mouse : IGenerateForce
{
    public ForceGenerator_Mouse(Player player, MouseManager mouseManager)
    {
        this.player = player;
        this.mouseManager = mouseManager;
    }
    public override ForceEntity Generate()
    {
        if (mouseManager.IsMouseKeyDown() == false)
            return null;

        mouseManager.UpdateMousePosition();

        Vector3 playerPosition = player.transform.position;
        Vector3 mousePosition = mouseManager.GetMousePosition();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0.0f;

        return new ForceEntity(playerPosition, mousePosition);
    }

    private Player player = null;
    private MouseManager mouseManager = null;
}