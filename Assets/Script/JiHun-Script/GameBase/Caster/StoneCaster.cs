using jjh;
using UnityEngine;

public class StoneCaster : CasterBase
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject createObject;

    [SerializeField] private MouseManager mouseManager;
    [SerializeField] private CasterBase windCaster;

    public void SetModifier(IMassModifier modifier)
    {
        this.modifier = modifier;
    }
    public override void Initalize(Player player)
    {
        mouseManager.RegistMouseEvent(0, MouseEventType.Down, Cast);
    }
    public override void Finalize(Player player)
    {
        mouseManager.UnRegistMouseEvent(0, MouseEventType.Down, Cast);
    }
    
    public override bool PossibleCast()
    {
        return true;
    }

    public override void Cast()
    {
        GameObject obj = ObjectCreator.Instance.CreateObjectOrNull(createObject, player.transform.position);

        var rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(player.transform.right.x * 100.0f, 100.0f, 0.0f));

        MassManager massManager = player.GetObjectComponent<MassManager>();
        if(massManager != null && modifier != null)
        {
            massManager.RemoveModifier(modifier);
        }

        ChangeCaster(windCaster);
    }
    private IMassModifier modifier = null;
}
