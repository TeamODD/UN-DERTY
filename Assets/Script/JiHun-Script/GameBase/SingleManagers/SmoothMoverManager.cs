using System;
using System.Collections.Generic;
using UnityEngine;

public enum EMoveType : UInt16
{
    MoveTowards,    // ������ �ӵ��� �����̴� ���
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
        // �̵��� ���� Mover���� ���� ���� ��⿭�� �߰��մϴ�.
        foreach (SmoothMover smoothMover in registedMovers)
        {
            smoothMover.SmoothMove();
            if (smoothMover.FinishMove())
            {
                smoothMover.ExecuteCallback();
                removedMovers.Enqueue(smoothMover);
            }
        }

        // ��⿭�� �ִ� Mover���� ���� ����Ʈ���� �����ϰ� �����մϴ�.
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