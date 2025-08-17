using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField] int hp;
    public void AddHP(int addedHPValue)
    {
        hp += addedHPValue;
    }
}
