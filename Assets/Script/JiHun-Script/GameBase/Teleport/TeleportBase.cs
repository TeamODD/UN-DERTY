using UnityEngine;

public interface ITeleport
{
    public void Teleport(GameObject gameObject, Vector3 goToPosition);
}
public abstract class TeleportBase : MonoBehaviour, ITeleport
{
    public abstract void Teleport(GameObject gameObject, Vector3 goToPosition);
}
