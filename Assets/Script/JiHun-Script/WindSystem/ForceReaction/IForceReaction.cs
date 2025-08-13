using UnityEngine;

public abstract class IForceReaction : MonoBehaviour
{
    public abstract void Reaction(Vector3 force);
    public bool PossibleReact() { return bReact; }
    public void SetReact(bool bReact) { this.bReact = bReact; }
    private bool bReact = true;
}