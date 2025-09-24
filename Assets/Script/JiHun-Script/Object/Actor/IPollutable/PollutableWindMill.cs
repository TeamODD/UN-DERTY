using UnityEngine;

namespace jjh
{
    public class PollutableWindMill : PollutableBase
    {
        private void Start()
        {
            MakeNewWindCollisionEffect makeNewWindCollisionEffect = GetComponent<MakeNewWindCollisionEffect>();
            makeNewWindCollisionEffect.ActionGenerateWind += GenerateWindEvent;
        }
        private void GenerateWindEvent(WindEntity windEntity)
        {
            PollutableTriggerPlayer pollutableWithPlayer = windEntity.GetComponent<PollutableTriggerPlayer>();
            if (pollutableWithPlayer != null)
                pollutableWithPlayer.SetPollute(true);
        }
    }
}
