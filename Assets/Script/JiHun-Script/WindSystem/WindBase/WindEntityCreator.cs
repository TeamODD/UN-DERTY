using System.Collections.Generic;
using UnityEngine;

public class WindEntityCreator : MonoBehaviour
{
    [SerializeField] private WindEntity windEntity;
    [SerializeField] private float windSterngth;

    public WindEntity CreateWind(ForceEntity forceEntity)
    {
        float angle = Mathf.Atan2(forceEntity.Direction.y, forceEntity.Direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        WindEntity realObject = Instantiate(windEntity, forceEntity.StartPoint, rotation);

        float strength = calculateStrength();
        Vector3 offset = forceEntity.Direction * forceEntity.Distance * 0.5f;
        realObject.transform.position += offset;
        realObject.transform.localScale = new Vector3(forceEntity.Distance, realObject.transform.localScale.y
            , realObject.transform.localScale.z);
        realObject.SetWindDirection(forceEntity.Direction);
        realObject.SetWindStrength(strength);

        Destroy(realObject.gameObject, 4.0f);
        return realObject;
    }

    public void AddWindStrengthIncreaseValue(float windStrengthIncreaseValue)
    {
        windStrengthIncreaseValues.Enqueue(windStrengthIncreaseValue);
    }
    private float calculateStrength()
    {
        float finalStrength = windSterngth;
        while(windStrengthIncreaseValues.Count > 0)
            finalStrength *= windStrengthIncreaseValues.Dequeue();

        return finalStrength;
    }
    
    protected Queue<float> windStrengthIncreaseValues = new Queue<float>();
}