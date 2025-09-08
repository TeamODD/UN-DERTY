using System.Collections.Generic;
using UnityEngine;

public class WormMove : IBossMove
{
    public WormMove(Body tailBody)
    {
        this.tailBody = tailBody;

        routeFinder = new RouteFinder();
    }
    public void Move()
    {
        // ���� ��Ʈ ã��
        List<IStateCommand> commands = routeFinder.FindRoute(tailBody);
        foreach (IStateCommand command in commands)
        {
            Debug.Log(command);
        }
        // ��Ʈ �߰��ϱ�
        // �̵��ϱ�
    }
    private Body tailBody;
    private RouteFinder routeFinder;

}
