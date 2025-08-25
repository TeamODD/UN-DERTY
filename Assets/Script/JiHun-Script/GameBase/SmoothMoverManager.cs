using System;
using System.Collections.Generic;
using UnityEngine;

public enum EMoveType : UInt16
{
    MoveTowards,    // 일정한 속도로 움직이는 방식
}
public class SmoothMover
{
    public SmoothMover(ObjectBase beMovedObject, Vector3 targetPosition, EMoveType moveType
        , float speed)
    {
        this.beMovedObject = beMovedObject;
        this.targetPosition = targetPosition;
        this.moveType = moveType;
        this.speed = speed;
    }
    public void SmoothMove()
    {
        if(moveType == EMoveType.MoveTowards)
            moveWithMoveTowards();
    }
    public bool FinishMove()
    {
        if (beMovedObject.transform.position == targetPosition)
            return true;
        return false;
    }

    private void moveWithMoveTowards()
    {
        // speed * Time.deltaTime 만큼의 최대 이동 거리를 계산합니다.
        float step = speed * Time.deltaTime;
        beMovedObject.transform.position = Vector3.MoveTowards(beMovedObject.transform.position, targetPosition, step);
    }

    private ObjectBase beMovedObject;
    private Vector3 targetPosition;
    private EMoveType moveType;
    private float speed = 5f;
}
public class SmoothMoverManager : MonoBehaviour
{
    public static SmoothMoverManager Instance {  get; private set; }
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
    private void Update()
    {
        foreach (SmoothMover smoothMover in registedMovers)
        {
            smoothMover.SmoothMove();
            if(smoothMover.FinishMove())
                removedMovers.Enqueue(smoothMover);
        }
        while(removedMovers.Count > 0)
        {
            SmoothMover smoothMover = removedMovers.Dequeue();
            registedMovers.Remove(smoothMover);
        }
    }
    public void RegistMover(SmoothMover mover)
    {
        registedMovers.Add(mover);
    }
    private List<SmoothMover> registedMovers = new List<SmoothMover>();

    private Queue<SmoothMover> removedMovers = new Queue<SmoothMover>();
}
