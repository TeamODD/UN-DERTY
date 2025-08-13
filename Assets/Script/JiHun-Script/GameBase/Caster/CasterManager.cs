using UnityEngine;

public class CasterManager : MonoBehaviour
{
    [SerializeField] CasterBase caster;
    private void Update()
    {
        if (caster.PossibleCast())
            caster.Cast();
    }
    public void SetCaster(CasterBase caster)
    {
        this.caster = caster;
    }
}
