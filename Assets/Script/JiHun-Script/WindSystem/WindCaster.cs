using System.Collections.Generic;
using UnityEngine;

// �� �������� �׳� �������� ���°� ������?
public class WindCaster : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private List<IWindActivationCondition> windActivationConditions;

    [SerializeField] private WindGenerator windGenerator;
    [SerializeField] private IForceGenerator forceGenerator;
    [SerializeField] private IForceApplier forceApplier;

    private void Awake()
    {
        // �� ó������ �ٴڿ� ���� ������ ���� �ֱ� ������
        currentConditionCount = windActivationConditions.Count;
        player.onGroundActions += CountClear;
    }
    public void Update()
    {
        if (currentConditionCount == windActivationConditions.Count)
        {
            // �÷��̾ ���� �پ ���� �޾Ƽ� CollisionEnter�� ȣ���� �ȵǾ��� ���� �ֱ� ������
            if (player.IsOnGround())
                CountClear();
            return;
        }
        IWindActivationCondition condition = windActivationConditions[currentConditionCount];
        
        if (condition.PossibleWind() == false)
            return;

        bool isGenerate = windGenerator.GenerateWindOrNot(forceGenerator, forceApplier);
        if(isGenerate == true)
            DecreaseCount();
    }

    public void CountClear() { currentConditionCount = 0; Debug.Log("CountClear"); }

    // ���� ������ ���� �ϴ� Ƚ���� �پ��� ��ó�� ������, ������ ���������δ� ī��Ʈ�� �ø�
    public void DecreaseCount() { currentConditionCount += 1; Debug.Log("DecreaseCount"); }

    private int currentConditionCount = 0;
}
