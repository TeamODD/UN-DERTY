using UnityEngine;

public class WindGenerator : MonoBehaviour
{
    [SerializeField] private WindEffectMaker windEffectMaker;
    [SerializeField] private IForceGenerator forceGenerator;
    [SerializeField] private IForceApplier forceApplier;

    public void GenerateWind()
    {
        ForceEntity forceEntity = forceGenerator.GenerateForce();

        forceApplier.Apply(forceEntity);

        if (windEffectMaker != null)
            windEffectMaker.MakeWindEffect(forceEntity);
    }
}
