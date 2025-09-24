using UnityEngine;

namespace jjh
{
    public class Detergent : PassiveItem
    {
        public Detergent(string itemName) 
            : base(itemName)
        {
        }

        public override void AdjustPassive(GameObject owner)
        {
            
        }

        public override void UnAdjustPassive(GameObject owner)
        {
            // dp -= 1;
        }
    }
}