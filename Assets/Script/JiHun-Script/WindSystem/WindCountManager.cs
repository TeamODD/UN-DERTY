using System.Collections.Generic;
using UnityEngine;

public class WindCountManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private List<IWindActivationCondition> windActivationConditions;

    private void Awake()
    {
        // 맨 처음에는 바닥에 착지 안했을 수도 있기 때문에
        currentConditionCount = windActivationConditions.Count;
        player.onGroundActions += CountClear;
    }
    public IWindActivationCondition ReturnCurrentConditionOrNull()
    {
        if (currentConditionCount == windActivationConditions.Count)
            return null;
        return windActivationConditions[currentConditionCount];
    }

    public void CountClear() { currentConditionCount = 0; }

    // 내부 구현을 몰라도 일단 횟수가 줄어드는 것처럼 느끼게, 하지만 실질적으로는 카운트를 늘림
    public void DecreaseCount() { currentConditionCount += 1; }

    private int currentConditionCount = 0;
}
