using UnityEngine;

public class BasicForceReaction : IForceReaction
{
    [SerializeField] private GameObject refObject;
    private void Awake()
    {
        refObjRigidbody = refObject.GetComponent<Rigidbody2D>();
    }
    public override void Reaction(Vector3 force)
    {
        if (refObject != null)
            refObjRigidbody.AddForce(force, ForceMode2D.Force);
    }
    private Rigidbody2D refObjRigidbody = null;
}
