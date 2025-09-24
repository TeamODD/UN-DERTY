using UnityEngine;

namespace jjh
{
    public class PollutablePickedObject : PollutableBase
    {
        private void Start()
        {
            PickedObject pickedObject = GetComponent<PickedObject>();
            pickedObject.ActionPicked += PollutEffect;
        }
    }
}
