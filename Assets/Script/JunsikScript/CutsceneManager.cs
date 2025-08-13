using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [Header("앨범 UI")]
    public GameObject albumPanel;
    public Image[] photoSlots;        // 현재 페이지 사진 슬롯
    public Animator pageAnimator;     // 페이지 넘김 애니메이터

    [Header("설정")]
    public Sprite[] photoSprites;     // 컷씬 이미지들
    public bool autoMode = false;     // 자동 모드 여부
    public float autoDelay = 1.8f;    // 자동 모드 간격

    private int currentPhotoIndex = 0;
    private int currentSlotIndex = 0;
    private bool isCutsceneActive = false;

    void Start()
    {
        albumPanel.SetActive(false);
        StartCutscene();
    }

    public void StartCutscene()
    {
        albumPanel.SetActive(true);
        isCutsceneActive = true;
        currentPhotoIndex = 0;
        currentSlotIndex = 0;
        LoadNextPhoto();

        if (autoMode)
            StartCoroutine(AutoProgress());
    }

    void Update()
    {
        if (!isCutsceneActive) return;

        // 수동 진행
        if (!autoMode && Input.GetMouseButtonDown(0))
        {
            LoadNextPhoto();
        }

        // 스킵
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndCutscene();
        }
    }

    void LoadNextPhoto()
    {
        if (currentPhotoIndex >= photoSprites.Length)
        {
            EndCutscene();
            return;
        }

        photoSlots[currentSlotIndex].sprite = photoSprites[currentPhotoIndex];
        photoSlots[currentSlotIndex].gameObject.SetActive(true);

        currentPhotoIndex++;
        currentSlotIndex++;

        // 페이지 다 채우면 넘김
        if (currentSlotIndex >= photoSlots.Length)
        {
            StartCoroutine(TurnPage());
        }
    }

    IEnumerator AutoProgress()
    {
        while (isCutsceneActive)
        {
            yield return new WaitForSeconds(autoDelay);
            LoadNextPhoto();
        }
    }

    IEnumerator TurnPage()
    {
        pageAnimator.SetTrigger("Turn");
        yield return new WaitForSeconds(0.8f); // 애니메이션 대기
        foreach (var slot in photoSlots)
        {
            slot.gameObject.SetActive(false);
        }
        currentSlotIndex = 0;
    }

    public void OnPanelClick()
    {
        if (!isCutsceneActive || autoMode) return;
        LoadNextPhoto();
    }

    void EndCutscene()
    {
        StopAllCoroutines();
        isCutsceneActive = false;
        albumPanel.SetActive(false);
        SceneManager.LoadScene("GameScene"); // 돌아갈 씬 이름
    }
}
