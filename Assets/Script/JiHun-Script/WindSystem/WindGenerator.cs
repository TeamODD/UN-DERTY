using UnityEngine;

public class WindGenerator : MonoBehaviour
{
    [SerializeField] private WindEffectMaker windEffectMaker;
    [SerializeField] private IForceGenerator forceGenerator;
    [SerializeField] private IForceApplier forceApplier;
    [SerializeField] private ForceStrengthController forceStrengthController;

    public void GenerateWind()
    {
        ForceEntity forceEntity = forceGenerator.GenerateForce();

        //forceStrengthController.ControlForce(forceApplier);
        forceApplier.Apply(forceEntity);
        //forceStrengthController.RevertStrength(forceApplier);

        if (windEffectMaker != null)
            windEffectMaker.MakeWindEffect(forceEntity);
    }
}
