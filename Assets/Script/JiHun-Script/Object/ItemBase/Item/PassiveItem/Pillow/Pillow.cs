using UnityEngine;

namespace jjh
{
    public class Pillow : PassiveItem
    {
        public Pillow(string itemName) 
            : base(itemName)
        {
        }

        public override void AdjustPassive(GameObject owner)
        {
            
        }

        public override void UnAdjustPassive(GameObject owner)
        {
            // �ٽ��ϱ� �� dp�� �������� ���� �������� ����..?
        }
    }

}
