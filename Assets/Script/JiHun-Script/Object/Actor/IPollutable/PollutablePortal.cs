using UnityEngine;

namespace jjh
{
    public class PollutablePortal : PollutableBase
    {
        private void Start()
        {
            Portal portal = GetComponent<Portal>();
            portal.ActionPortalAct += (Portal portal) => { PollutEffect(); };
        }
    }
}
