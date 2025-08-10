using UnityEngine;

public abstract class IForceGenerator : MonoBehaviour
{
    public abstract ForceEntity GenerateForceOrNull();
}

