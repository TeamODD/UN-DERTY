using UnityEngine;

public class NPC : MonoBehaviour
{
    public void Interact()
    {
        if (DPmanager.Instance.CheckNPCCondition(5))
            Debug.Log("DP +5 : 오염 구역 진입");
        // else
        // Debug.Log("일반 NPC 반응.");
    }
}

