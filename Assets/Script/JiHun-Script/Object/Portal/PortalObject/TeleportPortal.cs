using System;
using UnityEngine;


public class TeleportPortal : PortalBase
{
    public event Action<GameObject, PortalBase> teleportComponentAction;
    public override void Active(GameObject gameObject)
    {
        if (teleportComponentAction != null)
            teleportComponentAction(gameObject, this);
    }
}
