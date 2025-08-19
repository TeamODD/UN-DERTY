using UnityEngine;

public class WindGenerator : MonoBehaviour
{
    [SerializeField] private WindEffectMaker windEffectMaker;

    [SerializeField] private IForceGenerator forceGenerator;
    [SerializeField] private IForceApplier forceApplier;
    [SerializeField] private ForceStrengthController forceStrengthController;
    [SerializeField] private GameObject windPrefab;

    public void SetForceApplier(IForceApplier forceApplier)
    {
        this.forceApplier = forceApplier;
    }
    public void GenerateWind()
    {
        ForceEntity forceEntity = forceGenerator.GenerateForce();

        // WindEntity windEntity = windCreator.CreateWind();
    }
}
