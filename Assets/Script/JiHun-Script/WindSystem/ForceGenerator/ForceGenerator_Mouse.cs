using UnityEngine;

public class ForceGenerator_Mouse : IForceGenerator
{
    [SerializeField] private GameObject player;
    [SerializeField] private MouseManager mouseManager;
    public override ForceEntity GenerateForce()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 mousePosition = mouseManager.GetMousePosition();

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0.0f;

        return new ForceEntity(playerPosition, mousePosition);
    }
}