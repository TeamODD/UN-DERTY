using jjh;
using System.Collections.Generic;
using UnityEngine;

// �� �������� �׳� �������� ���°� ������?
public class WindCaster : CasterBase
{
    [SerializeField] private List<ForceActivationConditionBase> windActivationConditions;
    [SerializeField] private WindGenerator windGenerator;
    [SerializeField] private Player player;

    protected override bool realCast()
    {
        if (PossibleCast() == false)
            return false;

        windGenerator.GenerateWind();
        DecreaseCount();
        return true;
    }
    public override void InitalizeCaster()
    {
        // �� ó������ �ٴڿ� ���� ������ ���� �ֱ� ������
        currentConditionCount = windActivationConditions.Count;
        player.onGroundActions += CountClear;
        windGenerator.SetActive(true);
    }
    public override void FinalizeCaster()
    {
        player.onGroundActions -= CountClear;
        windGenerator.SetActive(false);
    }

    public bool PossibleCast()
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
