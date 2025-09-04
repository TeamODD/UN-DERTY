using System;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float settingTime;
    private float remainingTime;
    public Action OnTimerEnd; // Ÿ�̸Ӱ� ������ ȣ��� �ݹ� �Լ�

    public Timer(float duration, Action onTimerEndCallback)
    {
        this.settingTime = duration;
        this.remainingTime = this.settingTime;
        this.OnTimerEnd = onTimerEndCallback;
    }

    public void UpdateTimer(float deltaTime)
    {
        if (remainingTime > 0)
            remainingTime -= deltaTime;
    }

    public bool IsFinished()
    {
        return remainingTime <= 0;
    }

    public void ClearTime()
    {
        remainingTime = settingTime;
    }

    public void ExecuteCallback()
    {
        OnTimerEnd?.Invoke();
    }
}

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance { get; private set; }

    private List<Timer> maintainTimers = new List<Timer>();
    private List<Timer> onceActiveTimers = new List<Timer>();
    private Queue<Timer> finishedTimers = new Queue<Timer>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        foreach (Timer timer in maintainTimers)
        {
            timer.UpdateTimer(Time.deltaTime);
            if (timer.IsFinished())
            {
                timer.ExecuteCallback();
                timer.ClearTime();
            }
        }
        // Ȱ��ȭ�� ��� Ÿ�̸��� �ð��� ������Ʈ�ϰ�, ���� Ÿ�̸Ӵ� ���� ��⿭�� �߰��մϴ�.
        foreach (Timer timer in onceActiveTimers)
        {
            timer.UpdateTimer(Time.deltaTime);
            if (timer.IsFinished())
            {
                timer.ExecuteCallback();
                finishedTimers.Enqueue(timer);
            }
        }
        // ��⿭�� �ִ� Ÿ�̸ӵ��� ���� ����Ʈ���� �����ϰ� �����ϰ�, �ݹ��� �����մϴ�.
        while (finishedTimers.Count > 0)
        {
            Timer timer = finishedTimers.Dequeue();
            onceActiveTimers.Remove(timer);
        }
    }

    public void RegistOnceTimer(Timer timer)
    {
        onceActiveTimers.Add(timer);
    }
    public void RegistMaintainTimer(Timer timer)
    {
        maintainTimers.Add(timer);
    }
    public void RemoveMaintainTimer(Timer timer)
    {
        maintainTimers.Remove(timer);
    }
}
