using UnityEngine;

public interface ICaster
{
    public bool PossibleCast();
    public void Cast();
}
public abstract class CasterBase : MonoBehaviour, ICaster
{
    public abstract void Cast();
    public abstract bool PossibleCast();
}
