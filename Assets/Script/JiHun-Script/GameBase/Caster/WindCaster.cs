using System.Collections.Generic;
using UnityEngine;

// �� �������� �׳� �������� ���°� ������?
public class WindCaster : CasterBase
{
    [SerializeField] private Player player;
    [SerializeField] private List<ForceActivationConditionBase> windActivationConditions;

    [SerializeField] private WindGenerator windGenerator;

    private void Awake()
    {
        // �� ó������ �ٴڿ� ���� ������ ���� �ֱ� ������
        currentConditionCount = windActivationConditions.Count;
        player.onGroundActions += CountClear;
    }
    public override void Cast()
    {
        windGenerator.GenerateWind();
        DecreaseCount();
    }

    public override bool PossibleCast()
    {
        if (currentConditionCount == windActivationConditions.Count)
        {
            // �÷��̾ ���� �پ ���� �޾Ƽ� CollisionEnter�� ȣ���� �ȵǾ��� ���� �ֱ� ������
            if (player.IsOnGround())
                CountClear();
            return false;
        }
        ForceActivationConditionBase condition = windActivationConditions[currentConditionCount];

        return condition.PossibleActiveForce();
    }
    public void CountClear() { currentConditionCount = 0; }

    // ���� ������ ���� �ϴ� Ƚ���� �پ��� ��ó�� ������, ������ ���������δ� ī��Ʈ�� �ø�
    public void DecreaseCount() { currentConditionCount += 1; }

    private int currentConditionCount = 0;
}
