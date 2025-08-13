using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [Header("�ٹ� UI")]
    public GameObject albumPanel;
    public Image[] photoSlots;        // ���� ������ ���� ����
    public Animator pageAnimator;     // ������ �ѱ� �ִϸ�����

    [Header("����")]
    public Sprite[] photoSprites;     // �ƾ� �̹�����
    public bool autoMode = false;     // �ڵ� ��� ����
    public float autoDelay = 1.8f;    // �ڵ� ��� ����

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

        // ���� ����
        if (!autoMode && Input.GetMouseButtonDown(0))
        {
            LoadNextPhoto();
        }

        // ��ŵ
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

        // ������ �� ä��� �ѱ�
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
        yield return new WaitForSeconds(0.8f); // �ִϸ��̼� ���
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
        SceneManager.LoadScene("GameScene"); // ���ư� �� �̸�
    }
}
