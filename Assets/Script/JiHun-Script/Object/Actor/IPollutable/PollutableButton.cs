using UnityEngine;

namespace jjh
{
    public class PollutableButton : PollutableBase
    {
        private void Start()
        {
            Button button = GetComponent<Button>();
            if (button == null)
                Debug.Log("PollutableButton: Button Is Empty!");

            button.ActionActivate += PollutEffect;
        }
    }
}