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
        Debug.Log("�̹��� ������ ĵ���� ����");
    }

    /*public void GaugeImage()
    {
        Debug.Log("��ɱ����ʿ�");
        gaugeImage.fillAmount = 1f;
    }*/

    public void ItemButton1()
    {
        Debug.Log("��ɱ����ʿ�");
    }

    public void ItemButton2()
    {
        Debug.Log("��ɱ����ʿ�");
    }

    public void ItemButton3()
    {
        Debug.Log("��ɱ����ʿ�");
    }

    public void MenuButton()
    {
        menuCanvas.SetActive(true);
        Debug.Log("����â ����");
    }
}
