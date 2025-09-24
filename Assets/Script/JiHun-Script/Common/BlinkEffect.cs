using System.Collections;
using UnityEngine;

public class BlinkingEffect : MonoBehaviour
{
    // 깜빡이게 할 렌더러 (스프라이트 또는 3D 모델)
    private Renderer objectRenderer;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    public void StartBlinking(float duration, float blinkInterval)
    {
        // 이미 실행 중인 코루틴이 있다면 멈추고 새로 시작합니다.
        StopAllCoroutines();
        StartCoroutine(BlinkCoroutine(duration, blinkInterval));
    }

    private IEnumerator BlinkCoroutine(float duration, float blinkInterval)
    {
        float timer = 0f;
        while (timer < duration)
        {
            // 렌더러를 껐다가 켠다
            objectRenderer.enabled = !objectRenderer.enabled;

            // 정해진 간격만큼 기다린다
            yield return new WaitForSeconds(blinkInterval);

            timer += blinkInterval;
        }

        // 깜빡임이 끝나면, 반드시 렌더러를 다시 켜서 보이게 만듭니다.
        objectRenderer.enabled = true;
    }
}