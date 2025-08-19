using UnityEngine;

public class CreateWindEvent : IGenerateSuccess
{
    public CreateWindEvent(WindEntityCreator windCreator)
    {
        this.windCreator = windCreator;
    }
    public void OnGenerateSuccess(ForceEntity forceEntity)
    {
        windCreator.CreateWind(forceEntity);
    }
    private WindEntityCreator windCreator;
}

public class BasicWindEntityCreator : WindEntityCreator
{
    [SerializeField] private WindEntity windEntity;

    // 그냥 세팅하려고 가져온놈
    [SerializeField] private WindGenerator windGenerator;

    private IGenerateSuccess generateSuccess = null;
    private void Awake()
    {
        generateSuccess = new CreateWindEvent(this);
        windGenerator.AddGenerateSuccessEvent(generateSuccess);
    }
    private void OnDestroy()
    {
        if (windGenerator != null)
            windGenerator.RemoveGenerateSuccessEvent(generateSuccess);
    }
    public override void CreateWind(ForceEntity forceEntity)
    {
        float angle = Mathf.Atan2(forceEntity.Direction.y, forceEntity.Direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        WindEntity realObject = Instantiate(windEntity, forceEntity.StartPoint, rotation);

        Vector3 offset = forceEntity.Direction * forceEntity.Distance * 0.5f;
        realObject.transform.position += offset;
        realObject.transform.localScale = new Vector3(forceEntity.Distance, realObject.transform.localScale.y
            , realObject.transform.localScale.z);
        realObject.SetWindDirection(forceEntity.Direction);

        Destroy(realObject, 4.0f);
    }
}
