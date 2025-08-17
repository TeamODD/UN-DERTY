using jjh;
using System.Collections.Generic;
using UnityEngine;

// 더 많이지면 그냥 상태패턴 쓰는게 나을듯?
public class WindCaster : CasterBase
{
    [SerializeField] private List<ForceActivationConditionBase> windActivationConditions;
    [SerializeField] private MouseManager mouseManager;

    [SerializeField] private WindGenerator windGenerator;

    private Player player;
    public override void Initalize(Player player)
    {
        this.player = player;
        // 맨 처음에는 바닥에 착지 안했을 수도 있기 때문에
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
