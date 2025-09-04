using UnityEngine;

public class Door : ObjectBase
{
    [SerializeField] private GameObject targetObject;
    private void Start()
    {
        originPosition = transform.position;
        toMover = new SmoothMover(this, targetObject.transform.position, EMoveType.MoveTowards, 3.0f);
        backMover = new SmoothMover(this, originPosition, EMoveType.MoveTowards, 3.0f);
        bAway = false;
    }
    public void OpenDoor()
    {
        if (bAway)
            SmoothMoverManager.Instance.RegistMover(backMover);
        else
            SmoothMoverManager.Instance.RegistMover(toMover);
    }
    private SmoothMover toMover;
    private SmoothMover backMover;
    private Vector3 originPosition = Vector3.zero;
    bool bAway;
}
