using UnityEngine;

public class Stone : UsePossessItem
{
    public Stone(ObjectBase owner, int count, CasterManager casterManager, CasterBase stoneCaster)
        : base("Stone", count)
    {
        massModifier = new MultiplyModifier(2.0f);

        ownerMassManager = owner.GetObjectComponent<MassManager>();
        this.casterManager = casterManager;
        this.stoneCaster = stoneCaster;
    }

    public override void Possess()
    {
        ownerMassManager.AddModifier(massModifier);
    }

    public override void UnPossess()
    {

    }

    public override void Use()
    {
        // 사용하면 돌던지기로 바꾸기
        casterManager.SetCaster(stoneCaster);
    }
    public IMassModifier GetModifier() { return massModifier; }
    // Transform
    private MassManager ownerMassManager = null;
    private IMassModifier massModifier = null;

    private CasterManager casterManager;
    private CasterBase stoneCaster;
}
