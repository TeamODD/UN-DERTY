using Unity.VisualScripting;
using UnityEngine;

public class WindMillController : MonoBehaviour
{
    [SerializeField] private WindEntityCreator windEntityCreator;
    private void Awake()
    {
        pollutionState = GetComponent<PollutionState>();
    }

    public void GenerateWind(float windDirectionX)
    {
        if (bAlreadyGenerateWind)
            return;

        // WindmillReaction이 동작하면 이 함수를 호출해줌
        Vector3 direction = windDirectionX < 0.0f ? Vector3.left : Vector3.right;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + direction;
        
        ForceEntity forceEntity = new ForceEntity(startPosition, endPosition);
        
        WindEntity windEntity = windEntityCreator.CreateWind(forceEntity);
        if (pollutionState.IsPollution())
            windEntity.AddComponent<PollutionWindEffect>();

        windEntity.OnDestroyed += releaseAlreadyGenerate;
        bAlreadyGenerateWind = true;
    }
    private void releaseAlreadyGenerate()
    {
        bAlreadyGenerateWind = false;
    }
    private PollutionState pollutionState;
    private bool bAlreadyGenerateWind;
}