using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyTextChange : MonoBehaviour
{
    public TMP_Text[] txt;

    void Start()
    {

        for (int i = 0; i < txt.Length; i++)
        {
            txt[i].text = KeySetting.keys[(KeyInput)i].ToString();
        }
    }

    void Update()
    {
        KeycodeChange();
    }

    private void KeycodeChange()
    {
        for (int i = 0; i < txt.Length; i++)
        {
            txt[i].text = KeySetting.keys[(KeyInput)i].ToString();
        }
    }

}

