using UnityEngine;

public class NPC : MonoBehaviour
{
    public void Interact()
    {
        if (DPmanager.Instance.CheckNPCCondition(5))
            Debug.Log("DP +5 : ���� ���� ����");
        // else
        // Debug.Log("�Ϲ� NPC ����.");
    }
}

