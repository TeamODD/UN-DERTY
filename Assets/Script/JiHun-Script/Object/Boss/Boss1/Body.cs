using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] private Body linkedBody = null;
    public Body GetLinkedBody() {  return linkedBody; }
}
