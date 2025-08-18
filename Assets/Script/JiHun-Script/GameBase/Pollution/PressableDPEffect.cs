using UnityEngine;

public class PressableDPEffect : MonoBehaviour
{
    private void Awake()
    {
        // 버튼과 같은 오브젝트에 붙히기
        pollutionState = GetComponent<PollutionState>();
        if (pollutionState == null)
            Debug.Log("PressableDPEffect: PollutionState Is Null");

        Button button = GetComponent<Button>();
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
    private PollutionState pollutionState;
}
