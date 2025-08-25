using UnityEngine;

// 이 스크립트는 Rigidbody2D가 있는 게임 오브젝트에 붙여서 사용합니다.
[RequireComponent(typeof(Rigidbody2D))]
public class Drag : MonoBehaviour
{
    [SerializeField] private float dragCoefficient = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        // 이 스크립트가 붙어있는 게임 오브젝트의 Rigidbody2D 컴포넌트를 찾아옵니다.
        rb = GetComponent<Rigidbody2D>();
    }

    // 물리 관련 로직은 반드시 FixedUpdate에서 처리해야 합니다.
    private void FixedUpdate()
    {
        // 현재 X축 속도를 가져옵니다.
        float currentVelocityX = rb.linearVelocityX;

        // X축 속도가 0에 가깝다면 굳이 저항을 계산할 필요가 없습니다.
        if (Mathf.Abs(currentVelocityX) < 0.01f)
            return;

        // 저항력은 현재 움직이는 방향의 '반대' 방향으로 작용해야 합니다.
        // 따라서 현재 속도에 -1을 곱해 방향을 뒤집고, 저항 계수를 곱해 힘의 크기를 정합니다.
        float dragForceX = -currentVelocityX * dragCoefficient;

        // Y축에는 영향을 주지 않고, 오직 X축으로만 저항력을 가합니다.
        Vector2 dragForce = new Vector2(dragForceX, 0);

        // 계산된 저항력을 Rigidbody에 적용합니다.
        rb.AddForce(dragForce);
    }
}
