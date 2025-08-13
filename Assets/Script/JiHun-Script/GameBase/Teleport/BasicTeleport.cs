using UnityEngine;

public class BasicTeleport : TeleportBase
{
    public override void Teleport(GameObject gameObject, Vector3 goToPosition)
    {
        gameObject.transform.position = goToPosition;
    }
}
