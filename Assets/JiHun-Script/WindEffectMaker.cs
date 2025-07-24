using Unity.VisualScripting;
using UnityEngine;

public class WindEffectMaker : MonoBehaviour
{
    public GameObject windEffectPrefab;
    public void MakeWindEffect(ForceEntity forceEntity)
    {
        float angle = Mathf.Atan2(forceEntity.Direction.y, forceEntity.Direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject realObject = Instantiate(windEffectPrefab, forceEntity.StartPoint, rotation);
        
        Vector3 offset = forceEntity.Direction * forceEntity.Distance * 0.5f;
        realObject.transform.position += offset;
        realObject.transform.localScale = new Vector3(forceEntity.Distance, realObject.transform.localScale.y, realObject.transform.localScale.z);

        Destroy(realObject, 4.0f);
        // 사라질때 페이드아웃적용
    }
}
