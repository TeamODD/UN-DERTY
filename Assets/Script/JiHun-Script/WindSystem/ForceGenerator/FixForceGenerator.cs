using UnityEngine;

public class FixForceGenerator : IForceGenerator
{
    public override ForceEntity GenerateForce()
    {
        return new ForceEntity(startPosition, endPosition);
    }
    public void SetStartPosition(Vector3 startPosition) { this.startPosition = startPosition; }
    public void SetEndPosition(Vector3 endPosition) { this.endPosition = endPosition; }
    private Vector3 direction;
    private Vector3 startPosition;
    private Vector3 endPosition;
}
