using System;
using System.Collections.Generic;
using UnityEngine;

public class WindSystem : MonoBehaviour
{
    [SerializeField] private WindEffectMaker windEffectMaker;
    [SerializeField] private MouseManager mouseManager;
    [SerializeField] private IForceApplier forceApplier;
    [SerializeField] private IForceGenerator forceGenerator;
    [SerializeField] private ForceReactionStorage storage;
    [SerializeField] private WindCountManager windCountManager;

    void Update()
    {
        IWindActivationCondition windActivationCondition = windCountManager.ReturnCurrentConditionOrNull();

        if (windActivationCondition == null)
            return;

        if (windActivationCondition.PossibleWind() == false)
            return;

        ForceEntity forceEntity = forceGenerator.Generate();
        
        if (forceEntity != null)
        {
            forceApplier.Apply(forceEntity, storage);
            windEffectMaker.MakeWindEffect(forceEntity);
            windCountManager.DecreaseCount();   // 바람을 발생시키면 바람횟수 감소
        }
    }
}
