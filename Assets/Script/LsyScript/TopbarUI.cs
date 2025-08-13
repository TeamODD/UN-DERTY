using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopbarUI : MonoBehaviour
{
    public static bool GameIsPaused = false;

    //[SerializeField] private Image gaugeImage;
    [SerializeField] private GameObject topbarCanvas;
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject profileCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                menuCanvas.SetActive(false);
                Time.timeScale = 1f;
                GameIsPaused = false;
            }
            else
            {
                menuCanvas.SetActive(true);
                Time.timeScale = 0f;
                GameIsPaused = true;
            }
        }
    }

    public void ProfileButton()
    {
        profileCanvas.SetActive(true);
        Debug.Log("이미지 누르면 캔버스 열림");
    }

    /*public void GaugeImage()
    {
        Debug.Log("기능구현필요");
        gaugeImage.fillAmount = 1f;
    }*/

    public void ItemButton1()
    {
        Debug.Log("기능구현필요");
    }

    public void ItemButton2()
    {
        Debug.Log("기능구현필요");
    }

    public void ItemButton3()
    {
        Debug.Log("기능구현필요");
    }

    public void MenuButton()
    {
        menuCanvas.SetActive(true);
        Debug.Log("설정창 켜짐");
    }
}
