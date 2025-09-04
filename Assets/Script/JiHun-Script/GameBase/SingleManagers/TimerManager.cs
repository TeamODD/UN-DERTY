using System;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float settingTime;
    private float remainingTime;
    public Action OnTimerEnd; // 타이머가 끝나면 호출될 콜백 함수

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
        // 활성화된 모든 타이머의 시간을 업데이트하고, 끝난 타이머는 제거 대기열에 추가합니다.
        foreach (Timer timer in onceActiveTimers)
        {
            timer.UpdateTimer(Time.deltaTime);
            if (timer.IsFinished())
            {
                timer.ExecuteCallback();
                finishedTimers.Enqueue(timer);
            }
        }
        // 대기열에 있는 타이머들을 실제 리스트에서 안전하게 제거하고, 콜백을 실행합니다.
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
