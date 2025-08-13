using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    [SerializeField] private GameObject menuCanvas;

    void Start()
    {
        TopbarUI.GameIsPaused = true;
    }

    public void ResumeButton()
    {
        menuCanvas.SetActive(false);
        Time.timeScale = 1f;
        TopbarUI.GameIsPaused = false;
        Debug.Log("테스트 불가");
    }

    public void ReplayButton()
    {
        Debug.Log("기능구현필요");
    }

    public void TitleButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
        Debug.Log("씬전환완료");
    }

    public void SettingButton()
    {
        Debug.Log("기능구현필요");
    }

    public void QuitButton()
    {
        Debug.Log("게임 종료");
        //저장하는 코드 필요
        Application.Quit();
    }
}
