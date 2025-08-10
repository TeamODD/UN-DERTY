using System.Collections.Generic;
using UnityEngine;

public class WindCountManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private List<IWindActivationCondition> windActivationConditions;

    private void Awake()
    {
        // �� ó������ �ٴڿ� ���� ������ ���� �ֱ� ������
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

    // ���� ������ ���� �ϴ� Ƚ���� �پ��� ��ó�� ������, ������ ���������δ� ī��Ʈ�� �ø�
    public void DecreaseCount() { currentConditionCount += 1; }

    private int currentConditionCount = 0;
}
