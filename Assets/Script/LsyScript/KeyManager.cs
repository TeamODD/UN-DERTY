using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyInput
{
    Item1,
    Item2,
    Item3,
    KEYCOUNT
}

public static class KeySetting
{
    public static Dictionary<KeyInput, KeyCode> keys = new Dictionary<KeyInput, KeyCode>();
}

public class KeyManager : MonoBehaviour
{

    KeyCode[] defaultKeys = new KeyCode[] {
        KeyCode.Alpha1, //Item1
        KeyCode.Alpha2, //Item2
        KeyCode.Alpha3, //Item3
    };

    int key = -1;

    private void Awake()
    {
        KeySetting.keys.Clear();
        for (int i = 0; i < (int)KeyInput.KEYCOUNT; i++)
        {
            KeySetting.keys.Add((KeyInput)i, defaultKeys[i]);
        }
    }

    private void Update()
    {
        if (key == -1)
        {
            TestInput();
        }
    }

    private void OnGUI()
    {
        Event keyEvent = Event.current;
        if (key >= 0 && keyEvent.isKey)
        {

            if (KeySetting.keys.ContainsValue(keyEvent.keyCode))
            {
                Debug.LogWarning("해당 키는 이미 사용 중입니다!");
                key = -1;
            }
            else
            {
                KeySetting.keys[(KeyInput)key] = keyEvent.keyCode;
                key = -1;
            }
        }
    }

    public void ChangeKey(int num)
    {
        key = num;
    }

    private void TestInput()
    {
        
        if (Input.GetKeyDown(KeySetting.keys[KeyInput.Item1])) //item1
        {
            Debug.Log("아이템 1");
        }
        if (Input.GetKeyDown(KeySetting.keys[KeyInput.Item2])) //Item2
        {
            Debug.Log("아이템 2");
        }
        if (Input.GetKeyDown(KeySetting.keys[KeyInput.Item3])) //Item3
        {
            Debug.Log("아이템 3");
        }
    }
}