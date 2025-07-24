using UnityEngine;

public class InputModel : MonoBehaviour
{
    [SerializeField] private SettingUIInput _settingUIInput;

    public IInputable GetInputByType(InputType inputType)
    {
        switch (inputType)
        {
            case InputType.SettingUIInput:
                return _settingUIInput;
            default:
                return null;
        }
    }
}
