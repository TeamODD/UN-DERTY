using UnityEngine;

public class MouseManager
{
    public void UpdateMousePosition()
    {
        /*
          - 메뉴에서 Edit → Project Settings → Player로 이동
          - 오른쪽에서 Other Settings → Configuration → Active Input Handling 항목을 "Both"로 변경
        */
        mousePos = Input.mousePosition;
    }
    public Vector3 GetMousePosition() { return new Vector3(mousePos.x, mousePos.y, mousePos.z); }
    public bool IsMouseKeyDown() { return Input.GetMouseButtonDown(0); }

    private Vector3 mousePos = Vector3.zero;
}
