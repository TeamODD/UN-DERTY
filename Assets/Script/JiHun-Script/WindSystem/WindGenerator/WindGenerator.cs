using System.Collections.Generic;
using UnityEngine;

public interface IGenerateSuccess
{
    public void OnGenerateSuccess(ForceEntity forceEntity);
}
public class WindGenerator : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private jjh.MouseManager mouseManager;

    public void SetActive(bool bActive)
    {
        this.bActive = bActive;
    }
    public void Awake()
    {
        mouseManager.RegistMouseEvent(0, jjh.MouseEventType.Down, GenerateWind);
    }
    private void OnDestroy()
    {
        mouseManager.UnRegistMouseEvent(0, jjh.MouseEventType.Down, GenerateWind);
    }
    public void AddGenerateSuccessEvent(IGenerateSuccess generateSuccess)
    {
        generateSuccessEvents.Add(generateSuccess);
    }
    public void RemoveGenerateSuccessEvent(IGenerateSuccess generateSuccess)
    {
        generateSuccessEvents.Remove(generateSuccess);
    }
    public void GenerateWind()
    {
        if (bActive == false)
            return;

        Vector3 playerPosition = player.transform.position;
        Vector3 mousePosition = mouseManager.GetMousePosition();

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0.0f;

        ForceEntity forceEntity = new ForceEntity(playerPosition, mousePosition);
        foreach (IGenerateSuccess generateSuccessEvent in generateSuccessEvents)
            generateSuccessEvent.OnGenerateSuccess(forceEntity);
    }

    private List<IGenerateSuccess> generateSuccessEvents = new List<IGenerateSuccess>();
    private bool bActive = true;
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
