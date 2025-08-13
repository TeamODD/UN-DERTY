using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject menuCanvas;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LsyScene");
        Debug.Log("씬전환완료");
    }

    public void ReloadButton()
    {

    }

    public void ExitButton()
    {
        Debug.Log("게임 종료");
        //저장하는 코드 필요
        Application.Quit();
    }

    public void MenuButton()
    {
        menuCanvas.SetActive(true);
        Debug.Log("설정창 켜짐");
    }
}
