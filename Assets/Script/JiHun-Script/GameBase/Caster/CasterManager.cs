using UnityEngine;

public class CasterManager : MonoBehaviour
{
    [SerializeField] private jjh.MouseManager mouseManager;

    [SerializeField] private Player player;

    [SerializeField] private CasterBase currentCaster;
    private void Awake()
    {
        if (currentCaster == null)
        {
            Debug.Log("CasterManager: CurrentCaster Is Null");
            return;
        }
        SetCaster(currentCaster);
    }

    public void SetCaster(CasterBase caster)
    {
        if (currentCaster != null)
        {
            currentCaster.Finalize(player);
            currentCaster.OnChangeCaster -= SetCaster;
        }

        currentCaster = caster;

        currentCaster.Initalize(player);
        currentCaster.OnChangeCaster += SetCaster;
    }
}