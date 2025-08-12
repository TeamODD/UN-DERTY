using UnityEngine;

public interface ITeleport
{
    public void Teleport(GameObject gameObject, Vector3 goToPosition);
}
public class TeleportComponent : MonoBehaviour, ITeleport
{
    public void Teleport(GameObject gameObject, Vector3 goToPosition)
    {
        gameObject.transform.position = goToPosition;
    }
}
