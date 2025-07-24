using UnityEngine;

public class MouseManager
{
    public void UpdateMousePosition()
    {
        /*
          - �޴����� Edit �� Project Settings �� Player�� �̵�
          - �����ʿ��� Other Settings �� Configuration �� Active Input Handling �׸��� "Both"�� ����
        */
        mousePos = Input.mousePosition;
    }
    public Vector3 GetMousePosition() { return new Vector3(mousePos.x, mousePos.y, mousePos.z); }
    public bool IsMouseKeyDown() { return Input.GetMouseButtonDown(0); }

    private Vector3 mousePos = Vector3.zero;
}
