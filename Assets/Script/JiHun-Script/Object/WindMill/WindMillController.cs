using UnityEngine;

public class WindMillController : MonoBehaviour
{
    [SerializeField] private GameObject windMill;
    [SerializeField] private PollutionState pollutionState;

    [SerializeField] private WindEntityCreator windEntityCreator;

    [SerializeField] private float windStrength;
    public void Awake()
    {
        // pollutionState.IsPollution();
        // pollutionState.OnSetPollutionState += applier.SetIsPollution;

    }
    public void GenerateWind(float windDirectionX)
    {
        // WindmillReaction이 동작하면 이 함수를 호출해줌
        Vector3 direction = windDirectionX < 0.0f ? Vector3.left : Vector3.right;
        Vector3 startPosition = windMill.transform.position;
        Vector3 endPosition = startPosition + direction * windStrength;
        
        ForceEntity forceEntity = new ForceEntity(startPosition, endPosition);
        
        windEntityCreator.CreateWind(forceEntity);
    }
}