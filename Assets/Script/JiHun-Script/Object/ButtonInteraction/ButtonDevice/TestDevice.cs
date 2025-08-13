using UnityEngine;

public class TestDevice : IButtonDevice
{
    public override void ButtonInteract()
    {
        Debug.Log("Hi");
    }
}
