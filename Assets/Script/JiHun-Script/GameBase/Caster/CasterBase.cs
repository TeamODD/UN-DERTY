using System;
using UnityEngine;

public interface ICaster
{
    public bool PossibleCast();
    public void Cast();
}
public abstract class CasterBase : MonoBehaviour, ICaster
{
    public event Action<CasterBase> OnChangeCaster;
    protected void ChangeCaster(CasterBase caster)
    {
        OnChangeCaster.Invoke(caster);
    }
    public abstract void Cast();
    public abstract bool PossibleCast();
    public abstract void Initalize(Player player);
    public abstract void Finalize(Player player);
}
