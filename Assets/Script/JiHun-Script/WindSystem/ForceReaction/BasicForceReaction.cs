using UnityEngine;

public class BasicForceReaction : IForceReaction
{
    [SerializeField] private GameObject refObject;
    private void Awake()
    {
        refObjRigidbody = refObject.GetComponent<Rigidbody2D>();
    }
    public override void Reaction(Vector3 strength)
    {
        refObjRigidbody.AddForce(strength, ForceMode2D.Force);
    }
    private Rigidbody2D refObjRigidbody = null;
}
