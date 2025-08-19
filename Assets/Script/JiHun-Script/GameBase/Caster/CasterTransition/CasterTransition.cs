using UnityEngine;

public abstract class CasterTransition : MonoBehaviour
{
    [SerializeField] protected CasterManager manager;
    [SerializeField] protected CasterBase caster1;
    [SerializeField] protected CasterBase caster2;

    public void ChangeCaster()
    {
        if (manager.IsCurrentCaster(caster1) == false)
            return;

        manager.SetCurrentCaster(caster2);
    }
}
