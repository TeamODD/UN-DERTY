using System.Collections;
using UnityEngine;

public class BlinkingEffect : MonoBehaviour
{
    // �����̰� �� ������ (��������Ʈ �Ǵ� 3D ��)
    private Renderer objectRenderer;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    public void StartBlinking(float duration, float blinkInterval)
    {
        // �̹� ���� ���� �ڷ�ƾ�� �ִٸ� ���߰� ���� �����մϴ�.
        StopAllCoroutines();
        StartCoroutine(BlinkCoroutine(duration, blinkInterval));
    }

    private IEnumerator BlinkCoroutine(float duration, float blinkInterval)
    {
        float timer = 0f;
        while (timer < duration)
        {
            // �������� ���ٰ� �Ҵ�
            objectRenderer.enabled = !objectRenderer.enabled;

            // ������ ���ݸ�ŭ ��ٸ���
            yield return new WaitForSeconds(blinkInterval);

            timer += blinkInterval;
        }

        // �������� ������, �ݵ�� �������� �ٽ� �Ѽ� ���̰� ����ϴ�.
        objectRenderer.enabled = true;
    }
}