using UnityEngine;

public class ScaleFixture : MonoBehaviour
{
    [SerializeField] private GameObject scaleObject;
    void Update()
    {
        float y = transform.position.y + transform.localScale.y;
        Vector3 fixPosition = new Vector3(transform.position.x, y, transform.position.z);
        scaleObject.transform.position = fixPosition;
    }
}
