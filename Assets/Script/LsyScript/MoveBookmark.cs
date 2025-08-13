using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBookmark : MonoBehaviour
{
    private MainUI mainUI;
    public float moveSpeed = 30f;
    public float moveDistance = 60f;
    private Vector3 targetPosition;
    private Vector3 originPosition;

    private bool isHovering = false;


    private void Awake()
    {
        originPosition = gameObject.transform.position;
        targetPosition = gameObject.transform.position + Vector3.right * moveDistance;
    }

    private void Update()
    {
        if (isHovering)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, originPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void MouseIn()
    {
        isHovering = true;
    }

    public void MouseOut()
    {
        isHovering = false;
    }

    public void StartBtu()
    {
        isHovering = false;
        mainUI.StartButton();
    }

    public void ReloadBtu()
    {
        isHovering = false;
        mainUI.ReloadButton();
    }

    public void ExitBtu()
    {
        isHovering = false;
        mainUI.ExitButton();
    }
}