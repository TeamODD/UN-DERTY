using UnityEngine;

public class StoneToWindTransition : CasterTransition
{
    private void Awake()
    {
        StoneCaster stoneCaster = caster1 as StoneCaster;
        if (stoneCaster != null)
            stoneCaster.OnCastSuccess += ChangeCaster;
    }
}
