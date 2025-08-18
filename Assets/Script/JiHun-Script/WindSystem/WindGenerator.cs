using UnityEngine;

public class WindGenerator : MonoBehaviour
{
    [SerializeField] private WindEffectMaker windEffectMaker;
    [SerializeField] private IForceGenerator forceGenerator;
    [SerializeField] private IForceApplier forceApplier;
    [SerializeField] private ForceStrengthController forceStrengthController;

    public void SetForceApplier(IForceApplier forceApplier)
    {
        this.forceApplier = forceApplier;
    }
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
