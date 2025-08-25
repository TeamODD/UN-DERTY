using jjh;
using System.Collections.Generic;
using UnityEngine;

public class UseStrengthenNextWind : IUse
{
    public UseStrengthenNextWind(WindEntityCreator windEntityCreator, float strengthenValue)
    {
        this.windEntityCreator = windEntityCreator;
        this.strengthenValue = strengthenValue;
    }
    public void Use(ObjectBase ownerObject)
    {
        windEntityCreator.AddWindStrengthIncreaseValue(strengthenValue);
    }
    private WindEntityCreator windEntityCreator = null;
    private float strengthenValue = 0;
}

// �� �������� �׳� �������� ���°� ������?
public class WindCaster : CasterBase
{
    [SerializeField] private List<ForceActivationConditionBase> windActivationConditions;
    [SerializeField] private Player player;

    [SerializeField] private jjh.MouseManager mouseManager;

    [SerializeField] private ForceGenerator windGenerator;
    [SerializeField] private WindEntityCreator windEntityCreator;

    private void Awake()
    {
        ItemCreator itemCreator = ItemCreatorManager.Instance.GetItemCreator("Ballon");
        itemCreator.AddUse(new UseStrengthenNextWind(windEntityCreator, 1.5f));
    }
    protected override bool realCast()
    {
        if (PossibleCast() == false)
            return false;

        ForceEntity forceEntity = windGenerator.GenerateWind();

        windEntityCreator.CreateWind(forceEntity);
        DecreaseCount();

        return true;
    }
    public override void InitalizeCaster()
    {
        // �� ó������ �ٴڿ� ���� ������ ���� �ֱ� ������
        currentConditionCount = windActivationConditions.Count;
        player.onGroundActions += CountClear;

        mouseManager.RegistMouseEvent(0, MouseEventType.Down, Cast);
    }
    public override void FinalizeCaster()
    {
        player.onGroundActions -= CountClear;

        mouseManager.UnRegistMouseEvent(0, MouseEventType.Down, Cast);
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
