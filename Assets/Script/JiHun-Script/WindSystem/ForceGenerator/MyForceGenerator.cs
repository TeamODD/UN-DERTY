using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IGenerateSuccess
{
    public void OnGenerateSuccess(ForceEntity forceEntity);
}
public class MyForceGenerator : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private jjh.MouseManager mouseManager;

    public void Awake()
    {
        mouseManager.RegistMouseEvent(0, jjh.MouseEventType.Down, GenerateForce);
    }
    private void OnDestroy()
    {
        mouseManager.UnRegistMouseEvent(0, jjh.MouseEventType.Down, GenerateForce);
    }

    public void AddGenerateSuccessEvent(IGenerateSuccess generateSuccess)
    {
        generateSuccessEvents.Add(generateSuccess);
    }
    public void RemoveGenerateSuccessEvent(IGenerateSuccess generateSuccess)
    {
        generateSuccessEvents.Remove(generateSuccess);
    }
    public void GenerateForce()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 mousePosition = mouseManager.GetMousePosition();

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0.0f;

        ForceEntity forceEntity = new ForceEntity(playerPosition, mousePosition);
        foreach (IGenerateSuccess generateSuccessEvent in generateSuccessEvents)
            generateSuccessEvent.OnGenerateSuccess(forceEntity);
    }

    private List<IGenerateSuccess> generateSuccessEvents = new List<IGenerateSuccess>();
}
