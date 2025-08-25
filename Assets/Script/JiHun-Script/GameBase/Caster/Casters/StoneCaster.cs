using jjh;
using UnityEngine;

public class StoneCaster : CasterBase
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject createObject;

    [SerializeField] private MouseManager mouseManager;

    private void Start()
    {
        ItemCreator itemCreator = ItemCreatorManager.Instance.GetItemCreator("Stone");
        if (itemCreator == null)
        {
            Debug.Log("StoneCaster: StoneCreator Is None");
            return;
        }

        massModifier = new MultiplyModifier(2.0f);
        itemCreator.AddPossess(new PossessIncreaseMass(massModifier));
        
    }
    public override void InitalizeCaster()
    {
        mouseManager.RegistMouseEvent(0, MouseEventType.Down, Cast);
    }
    public override void FinalizeCaster()
    {
        mouseManager.UnRegistMouseEvent(0, MouseEventType.Down, Cast);
    }

    protected override bool realCast()
    {
        GameObject obj = ObjectCreator.Instance.CreateObjectOrNull(createObject, player.transform.position);

        var rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(player.transform.right.x * 100.0f, 100.0f, 0.0f));

        MassManager playerMassManager = player.GetObjectComponent<MassManager>();
        if(playerMassManager != null)
            playerMassManager.RemoveModifier(massModifier);

        return true;
    }
    private IMassModifier massModifier = null;
}
