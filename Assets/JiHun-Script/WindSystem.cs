using System;
using System.Collections.Generic;
using UnityEngine;

public class WindSystem : MonoBehaviour
{
    public Player player;
    public WindEffectMaker windEffectMaker;
    public float windStrength;
    public float maxWindStrength;
    public float windCoefficient;
    public float windJudgementValue;

    void Awake()
    {
        storage = new ForceReactionStorage();
        mouseManager = new MouseManager();
        forceGenerator = new ForceGenerator_Mouse(player, mouseManager);
        applyForce = new ApplyForce(windStrength, maxWindStrength, windCoefficient);
        judgeWind = new JudgeByVelocity(player, windJudgementValue);
        
    }

    void Update()
    {
        if (judgeWind.PossibleWind() == false)
            return;

        ForceEntity forceEntity = forceGenerator.Generate();
        
        if (forceEntity != null)
        {
            applyForce.Apply(forceEntity, storage);
            windEffectMaker.MakeWindEffect(forceEntity);
        }
    }

    public void RegistApplyForceObject(GameObject applyForceObject, List<Action> actions)
    {
        storage.RegistApplyObject(applyForceObject, actions);
    }

    public void RemoveApplyForceObject(GameObject removeForceObject)
    {
        storage.RemoveApplyObject(removeForceObject);
    }

    private MouseManager mouseManager = null;
    private IGenerateForce forceGenerator = null;
    private ApplyForce applyForce = null;
    private ForceReactionStorage storage = null;
    private IJudgeWind judgeWind = null;

}
