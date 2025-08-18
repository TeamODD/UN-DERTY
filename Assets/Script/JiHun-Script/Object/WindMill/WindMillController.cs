using UnityEngine;

public class WindMillController : MonoBehaviour
{
    [SerializeField] private GameObject windMill;
    [SerializeField] private PollutionState pollutionState;

    [SerializeField] private WindGenerator windGenerator;
    [SerializeField] private WindMillApplier applier;
    [SerializeField] private FixForceGenerator fixForceGenerator;
    [SerializeField] private WindMillReaction windMillReaction;

    [SerializeField] private float windStrength;
    public void Awake()
    {
        windMillReaction.windGenerateAction += GenerateWind;
        applier.SetIsPollution(pollutionState.IsPollution());
        pollutionState.OnSetPollutionState += applier.SetIsPollution;

        windGenerator.SetForceApplier(applier);
    }
    private void GenerateWind(Vector3 force)
    {
        Vector3 direction = force.x < 0.0f ? Vector3.left : Vector3.right;
        Vector3 startPosition = windMill.transform.position;
        Vector3 endPosition = startPosition + direction * windStrength;

        fixForceGenerator.SetStartPosition(startPosition);
        fixForceGenerator.SetEndPosition(endPosition);

        windMillReaction.SetReact(false);
        windGenerator.GenerateWind();
        windMillReaction.SetReact(true);
    }
}
