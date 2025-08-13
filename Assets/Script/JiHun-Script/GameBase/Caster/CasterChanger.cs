using System;
using System.Collections.Generic;
using UnityEngine;

public interface ICastChange
{
    public event Action onCastChange;
}

public class CasterChanger : MonoBehaviour
{
    [SerializeField] private CasterManager castManager;
    [SerializeField] private List<CasterChangeItemBase> casterChangeItemBases;
    private void Awake()
    {
        foreach(var caster in casterChangeItemBases)
        {
            if (caster)
                caster.onCastChange += SetStoneCaster;
        }
    }
    void SetStoneCaster()
    {
        castManager.SetCaster(new WindCaster());
    }
}
