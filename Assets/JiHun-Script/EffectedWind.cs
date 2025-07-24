using UnityEngine;

public class EffectedWind : MonoBehaviour
{
    public WindSystem windSystem;
    void Start()
    {
        windSystem.RegistApplyForceObject(gameObject, null);
    }

    private void OnDestroy()
    {
        windSystem.RemoveApplyForceObject(gameObject);
    }
}
