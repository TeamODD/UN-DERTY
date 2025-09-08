using System.Collections.Generic;
using UnityEngine;

public interface IStateCommand
{
    void ExecuteRouteCommand(Body body);
}
public class RotationMoveState : IStateCommand
{
    public RotationMoveState(Vector2 direction, Quaternion rotation)
    {
        this.rotation = rotation;
        this.direction = new Vector3(direction.x, direction.y, 0.0f);
    }
    public void ExecuteRouteCommand(Body body)
    {
        body.transform.rotation = rotation;
        body.transform.position += direction;
    }
    private Quaternion rotation;
    private Vector3 direction;
}
public class MoveState : IStateCommand
{
    public MoveState(Vector2 direction)
    {
        this.direction = new Vector3(direction.x, direction.y, 0.0f);
    }
    public void ExecuteRouteCommand(Body body)
    {
        body.transform.position += direction;
    }
    private Vector3 direction;
}
public class NoneState : IStateCommand
{
    public void ExecuteRouteCommand(Body body)
    {
        return;
    }
}
public class RouteFinder
{
    public List<IStateCommand> FindRoute(Body tailBody)
    {
        List<IStateCommand> routeCommands = new List<IStateCommand>();
        Body currentBody = tailBody;
        Vector2 prevDirection = Vector2.zero;
        while(true)
        {
            Body linkedBody = currentBody.GetLinkedBody();
            if (linkedBody == null)
                break;

            Vector2 currentDirection = findDirection(currentBody, linkedBody);

            if (currentDirection != prevDirection)
            {
                float angle = Vector2.SignedAngle(prevDirection, currentDirection);
                Quaternion q = Quaternion.Euler(0.0f, 0.0f, angle);
                routeCommands.Add(new RotationMoveState(currentDirection, q));
            }
            else
                routeCommands.Add(new MoveState(currentDirection));

            Debug.Log(currentDirection);
            prevDirection = currentDirection;
            currentBody = linkedBody;
        }
        return routeCommands;
    }
    private Vector2 findDirection(Body baseBody, Body linkedBody)
    {
        if (baseBody.transform.position.x + baseBody.transform.localScale.x / 2.5f < linkedBody.transform.position.x)
            return new Vector2(1.0f, 0.0f);
        else if (baseBody.transform.position.x - baseBody.transform.localScale.x / 2.5f > linkedBody.transform.position.x)
            return new Vector2(-1.0f, 0.0f);
        else if (baseBody.transform.position.y + baseBody.transform.localScale.y / 2.5f < linkedBody.transform.position.y)
            return new Vector2(0.0f, 1.0f);
        else
            return new Vector2(0.0f, -1.0f);
    }
}
