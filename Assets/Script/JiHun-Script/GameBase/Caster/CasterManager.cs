using UnityEngine;

public class CasterManager : MonoBehaviour
{
    [SerializeField] private CasterBase currentCaster;
    private void Awake()
    {
        if (currentCaster == null)
        {
            Debug.Log("CasterManager: CurrentCaster Is Null");
            return;
        }
        SetCurrentCaster(currentCaster);
    }
    public bool IsCurrentCaster(CasterBase caster) { return caster == currentCaster; }
    public void SetCurrentCaster(CasterBase caster)
    {
        if (currentCaster != null)
        {
            currentCaster.FinalizeCaster();
        }

        currentCaster = caster;

        currentCaster.InitalizeCaster();
    }
}