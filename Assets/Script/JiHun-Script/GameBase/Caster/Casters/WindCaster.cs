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

// 더 많이지면 그냥 상태패턴 쓰는게 나을듯?
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
        // 맨 처음에는 바닥에 착지 안했을 수도 있기 때문에
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
            // 플레이어가 땅에 붙어서 힘을 받아서 CollisionEnter가 호출이 안되었을 수도 있기 때문에
            if (player.IsOnGround())
                CountClear();
            return false;
        }
        ForceActivationConditionBase condition = windActivationConditions[currentConditionCount];

        return condition.PossibleActiveForce();
    }
    public void CountClear() { currentConditionCount = 0; }

    // 내부 구현을 몰라도 일단 횟수가 줄어드는 것처럼 느끼게, 하지만 실질적으로는 카운트를 늘림
    public void DecreaseCount() { currentConditionCount += 1; }

    private int currentConditionCount = 0;


}
