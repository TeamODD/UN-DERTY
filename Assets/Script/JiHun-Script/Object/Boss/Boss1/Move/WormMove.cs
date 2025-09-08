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
        // 현재 루트 찾기
        List<IStateCommand> commands = routeFinder.FindRoute(tailBody);
        foreach (IStateCommand command in commands)
        {
            Debug.Log(command);
        }
        // 루트 추가하기
        // 이동하기
    }
    private Body tailBody;
    private RouteFinder routeFinder;

}
