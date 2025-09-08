using System;
using System.Collections.Generic;
using UnityEngine;

public enum EMoveType : UInt16
{
    MoveTowards,    // 일정한 속도로 움직이는 방식
}
public class SmoothMover
{
    public event Action OnFinishMove;
    public SmoothMover(ObjectBase beMovedObject, Vector3 targetPosition, EMoveType moveType, float speed)
    {
        this.beMovedObject = beMovedObject;
        this.targetPosition = targetPosition;
        this.moveType = moveType;
        this.speed = speed;
    }
    public void SetTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
    public void SmoothMove()
    {
        if (beMovedObject == null)
            return;
        if (moveType == EMoveType.MoveTowards)
            moveWithMoveTowards();
    }

    public bool FinishMove()
    {
        if (beMovedObject == null)
            return true;

        return Vector3.Distance(beMovedObject.transform.position, targetPosition) < 0.001f;
    }
    public void ExecuteCallback()
    {
        OnFinishMove?.Invoke();
    }
    private void moveWithMoveTowards()
    {
        float step = speed * Time.deltaTime;
        beMovedObject.transform.position = Vector3.MoveTowards(beMovedObject.transform.position, targetPosition, step);
    }

    private ObjectBase beMovedObject;
    private Vector3 targetPosition;
    private EMoveType moveType;
    private float speed;
}
public class SmoothMoverManager : MonoBehaviour
{
    public static SmoothMoverManager Instance { get; private set; }

    private List<SmoothMover> registedMovers = new List<SmoothMover>();
    private Queue<SmoothMover> removedMovers = new Queue<SmoothMover>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        // 이동이 끝난 Mover들을 먼저 제거 대기열에 추가합니다.
        foreach (SmoothMover smoothMover in registedMovers)
        {
            smoothMover.SmoothMove();
            if (smoothMover.FinishMove())
            {
                smoothMover.ExecuteCallback();
                removedMovers.Enqueue(smoothMover);
            }
        }

        // 대기열에 있는 Mover들을 실제 리스트에서 안전하게 제거합니다.
        while (removedMovers.Count > 0)
        {
            SmoothMover smoothMover = removedMovers.Dequeue();
            registedMovers.Remove(smoothMover);
        }
    }

    public void RegistMover(SmoothMover mover)
    {
        if (mover != null)
            registedMovers.Add(mover);
    }
}