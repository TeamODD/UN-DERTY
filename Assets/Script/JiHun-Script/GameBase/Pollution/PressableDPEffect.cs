using UnityEngine;

public class PressableDPEffect : MonoBehaviour
{
    private void Awake()
    {
        // ��ư�� ���� ������Ʈ�� ������
        pollutionState = GetComponent<PollutionState>();
        if (pollutionState == null)
            Debug.Log("PressableDPEffect: PollutionState Is Null");

        button = GetComponent<Button>();
        if (button == null)
            Debug.Log("PressableDPEffect: Button Is Null");
        else
            button.OnClick += OnPressed;
    }
    public void OnPressed()
    {
        if (pollutionState.IsPollution() == false)
            return;

        DPmanager.Instance.AddDP(1);
    }
    private void OnDestroy()
    {
        if(button != null)
        {
            button.OnClick -= OnPressed;
        }
    }
    private PollutionState pollutionState;
    private Button button;
}
