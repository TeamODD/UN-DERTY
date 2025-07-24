using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType
{
    SettingUIInput
}

public class InputController : MonoBehaviour
{
    private IInputable _curInput;
    private InputModel _model;

    private void Update()
    {
        if (_curInput != null)
        {
            _curInput.ExecuteInput();
        }
    }

    public void SetCurInput(InputType inputType)
    {
        _curInput = _model.GetInputByType(inputType);
    }
}



