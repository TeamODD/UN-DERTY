using UnityEngine;

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

