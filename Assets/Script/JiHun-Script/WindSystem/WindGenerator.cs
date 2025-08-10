using UnityEngine;

public class WindGenerator : MonoBehaviour
{
    [SerializeField] private WindEffectMaker windEffectMaker;
    [SerializeField] private ForceReactionStorage storage;

    public bool GenerateWindOrNot(IForceGenerator forceGenerator, IForceApplier forceApplier)
    {
        ForceEntity forceEntity = forceGenerator.GenerateForceOrNull();

        if (forceEntity != null)
        {
            forceApplier.Apply(forceEntity, storage);
            //windEffectMaker.MakeWindEffect(forceEntity);
            return true;
        }
        else
            return false;
    }
}
