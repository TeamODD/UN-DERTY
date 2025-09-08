using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [SerializeField] private Body head;
    [SerializeField] private Body tail;
    private void Awake()
    {
        move = new WormMove(tail);
    }
    public void MoveBoss()
    {
        move.Move();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MoveBoss();
        }
    }

    private IBossMove move = null;
}
