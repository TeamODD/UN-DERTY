using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject SettingCanvas;

    void Start()
    {
        TopbarUI.GameIsPaused = true;
    }

    public void ResumeButton()
    {
        menuCanvas.SetActive(false);
        Time.timeScale = 1f;
        TopbarUI.GameIsPaused = false;
        Debug.Log("�׽�Ʈ �Ұ�");
    }

    public void ReplayButton()
    {
        Debug.Log("��ɱ����ʿ�");
    }

    public void TitleButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        Debug.Log("����ȯ�Ϸ�");
    }

    public void SettingButton()
    {
        SettingCanvas.SetActive(true);
        Debug.Log("����â ����");
        menuCanvas.SetActive(false);
    }

    public void QuitButton()
    {
        Debug.Log("���� ����");
        //�����ϴ� �ڵ� �ʿ�
        Application.Quit();
    }
}
