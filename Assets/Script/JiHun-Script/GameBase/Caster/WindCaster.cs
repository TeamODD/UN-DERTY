using jjh;
using System.Collections.Generic;
using UnityEngine;

// �� �������� �׳� �������� ���°� ������?
public class WindCaster : CasterBase
{
    [SerializeField] private List<ForceActivationConditionBase> windActivationConditions;
    [SerializeField] private MouseManager mouseManager;

    [SerializeField] private WindGenerator windGenerator;

    private Player player;
    public override void Initalize(Player player)
    {
        this.player = player;
        // �� ó������ �ٴڿ� ���� ������ ���� �ֱ� ������
        currentConditionCount = windActivationConditions.Count;
        player.onGroundActions += CountClear;

        mouseManager.RegistMouseEvent(0, MouseEventType.Down, Cast);
    }
    public override void Finalize(Player player)
    {
        player.onGroundActions -= CountClear;

        mouseManager.UnRegistMouseEvent(0, MouseEventType.Down, Cast);
    }

    public override void Cast()
    {
        if (PossibleCast() == false)
            return;

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
