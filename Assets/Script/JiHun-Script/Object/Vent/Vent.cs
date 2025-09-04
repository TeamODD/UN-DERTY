using UnityEngine;

public class Vent : ObjectBase
{
    [SerializeField] private WindEntityCreator windEntityCreator;
    [SerializeField] private float windPower;
    private void Awake()
    {
        startPosition = transform.position;
        endPosition = startPosition + transform.up * windPower;
    }
    private void Start()
    {
        generateWindTimer = new Timer(1.0f, GenerateWind);
    }
    public void GenerateWind()
    {
        ForceEntity forceEntity = new ForceEntity(startPosition, endPosition);

        WindEntity windEntity = windEntityCreator.CreateWind(forceEntity);
    }
    public void TurnOnOff()
    {
        if(bOn)
        {
            TimerManager.Instance.RemoveMaintainTimer(generateWindTimer);
            bOn = false;
        }
        else
        {
            TimerManager.Instance.RegistMaintainTimer(generateWindTimer);
            bOn = true;
        }
    }
    private Timer generateWindTimer = null;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 endPosition = Vector3.zero;
    private bool bOn = false;
}
