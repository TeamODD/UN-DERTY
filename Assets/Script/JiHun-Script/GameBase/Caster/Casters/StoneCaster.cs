using jjh;
using UnityEngine;

public class StoneCaster : CasterBase
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject createObject;

    [SerializeField] private MouseManager mouseManager;

    public void SetModifier(IMassModifier modifier)
    {
        this.modifier = modifier;
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

        MassManager massManager = player.GetObjectComponent<MassManager>();
        if(massManager != null && modifier != null)
            massManager.RemoveModifier(modifier);

        return true;
    }
    private IMassModifier modifier = null;
}
