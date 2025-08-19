using System;
using UnityEngine;

public abstract class CasterBase : MonoBehaviour
{
    public event Action OnCastSuccess;

    public void Cast()
    {
        if (realCast())
            OnCastSuccess?.Invoke();
    }
    protected abstract bool realCast();
    public abstract void InitalizeCaster();
    public abstract void FinalizeCaster();

}
