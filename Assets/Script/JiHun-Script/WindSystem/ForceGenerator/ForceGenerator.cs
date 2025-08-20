using UnityEngine;

public class ForceGenerator : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private jjh.MouseManager mouseManager;

    public ForceEntity GenerateWind()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 mousePosition = mouseManager.GetMousePosition();

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0.0f;

        ForceEntity forceEntity = new ForceEntity(playerPosition, mousePosition);
        return forceEntity;
    }
}

//public class FixForceGenerator : IForceGenerator
//{
//    public override ForceEntity GenerateForce()
//    {
//        return new ForceEntity(startPosition, endPosition);
//    }
//    public void SetStartPosition(Vector3 startPosition) { this.startPosition = startPosition; }
//    public void SetEndPosition(Vector3 endPosition) { this.endPosition = endPosition; }
//    private Vector3 direction;
//    private Vector3 startPosition;
//    private Vector3 endPosition;
//}
