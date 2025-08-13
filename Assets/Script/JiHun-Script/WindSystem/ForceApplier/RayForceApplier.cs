using UnityEngine;

public class RayForceApplier : IForceApplier
{
    [SerializeField] private float forceStrength;
    [SerializeField] private float coefficient;
    [SerializeField] private float maxStrength;
    public override void Apply(ForceEntity forceEntity)
    {
        Vector2 rayStartPoint = new Vector2(forceEntity.StartPoint.x, forceEntity.StartPoint.y);
        Vector2 rayDirection = new Vector2(forceEntity.Direction.x, forceEntity.Direction.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(rayStartPoint, rayDirection, forceEntity.Distance);

        foreach (RaycastHit2D hit in hits)
        {
            GameObject obj = hit.collider.gameObject;

            IForceReaction forceReaction = reactionStorage.ReturnObjectForceReactionOrNull(obj);

            if (forceReaction == null)
                continue;

            Vector2 objPosition = obj.transform.position;

            float strength = forceStrength * coefficient * forceEntity.Distance;
            if (strength > maxStrength)
                strength = maxStrength;

            Vector3 force = forceEntity.Direction * strength;

            this.activeReaction(forceReaction, force);
        }
    }
}