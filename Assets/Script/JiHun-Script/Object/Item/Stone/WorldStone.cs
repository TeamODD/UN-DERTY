using UnityEngine;

public class WorldStone : WorldItem
{
    [SerializeField] protected GameObject returnObject;
    [SerializeField] private CasterManager manager;
    [SerializeField] private StoneCaster stoneCaster;

    private PollutionState pollutionState = null;
    private Stone madeStone = null;
    private void Awake()
    {
        pollutionState = GetComponent<PollutionState>();
        if (pollutionState == null)
            Debug.Log("WorldStone: PollutionState Is Null");
    }
    public override ItemBase PickedUp(ObjectBase pickObject)
    {
        madeStone = new Stone(pickObject, 1, manager, stoneCaster);

        return madeStone;
    }
    protected override void OnSuccess()
    {
        IMassModifier modifier = madeStone.GetModifier();

        stoneCaster.SetModifier(modifier);

        if (pollutionState.IsPollution())
            DPmanager.Instance.AddDP(1);
    }
}
