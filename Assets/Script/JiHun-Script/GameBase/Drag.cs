using UnityEngine;

// �� ��ũ��Ʈ�� Rigidbody2D�� �ִ� ���� ������Ʈ�� �ٿ��� ����մϴ�.
[RequireComponent(typeof(Rigidbody2D))]
public class Drag : MonoBehaviour
{
    [SerializeField] private float dragCoefficient = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        // �� ��ũ��Ʈ�� �پ��ִ� ���� ������Ʈ�� Rigidbody2D ������Ʈ�� ã�ƿɴϴ�.
        rb = GetComponent<Rigidbody2D>();
    }

    // ���� ���� ������ �ݵ�� FixedUpdate���� ó���ؾ� �մϴ�.
    private void FixedUpdate()
    {
        // ���� X�� �ӵ��� �����ɴϴ�.
        float currentVelocityX = rb.linearVelocityX;

        // X�� �ӵ��� 0�� �����ٸ� ���� ������ ����� �ʿ䰡 �����ϴ�.
        if (Mathf.Abs(currentVelocityX) < 0.01f)
            return;

        // ���׷��� ���� �����̴� ������ '�ݴ�' �������� �ۿ��ؾ� �մϴ�.
        // ���� ���� �ӵ��� -1�� ���� ������ ������, ���� ����� ���� ���� ũ�⸦ ���մϴ�.
        float dragForceX = -currentVelocityX * dragCoefficient;

        // Y�࿡�� ������ ���� �ʰ�, ���� X�����θ� ���׷��� ���մϴ�.
        Vector2 dragForce = new Vector2(dragForceX, 0);

        // ���� ���׷��� Rigidbody�� �����մϴ�.
        rb.AddForce(dragForce);
    }
}
