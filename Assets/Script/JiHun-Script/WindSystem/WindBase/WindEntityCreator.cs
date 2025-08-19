using UnityEngine;

public abstract class WindEntityCreator : MonoBehaviour
{
    [SerializeField] private float windSterngth;
    public abstract void CreateWind(ForceEntity forceEntity);
}


