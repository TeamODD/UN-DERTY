using System;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private void Update()
    {
        /*
          - �޴����� Edit �� Project Settings �� Player�� �̵�
          - �����ʿ��� Other Settings �� Configuration �� Active Input Handling �׸��� "Both"�� ����
        */
        mousePos = Input.mousePosition;
    }
    public Vector3 GetMousePosition() { return new Vector3(mousePos.x, mousePos.y, mousePos.z); }
    public bool IsMouseKeyDown(int buttonFlag) { return Input.GetMouseButtonDown(buttonFlag); }

    private Vector3 mousePos = Vector3.zero;
}
