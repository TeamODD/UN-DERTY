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
            // 다시하기 시 dp를 스테이지 입장 시점으로 복원..?
        }
    }

}
