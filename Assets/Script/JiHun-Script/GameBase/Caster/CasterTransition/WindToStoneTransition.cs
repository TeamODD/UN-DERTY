using UnityEngine;

public class WindToStone : IUse
{
    public WindToStone(CasterTransition casterTransition)
    {
        this.casterTransition = casterTransition;
    }
    public void Use()
    {
        if (casterTransition != null)
            casterTransition.ChangeCaster();
    }
    private CasterTransition casterTransition = null;
}
public class WindToStoneTransition : CasterTransition
{
    [SerializeField] private WorldItem worldStone;
    private void Awake()
    {
        use = new WindToStone(this);
        worldStone.AddUse(use);
    }
    private IUse use = null;
}
