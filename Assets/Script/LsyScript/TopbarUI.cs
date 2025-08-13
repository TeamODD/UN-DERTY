using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopbarUI : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] private Image gaugeImage;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GaugeImage(0.1f);
        }
    }

    public void ProfileButton()
    {
        profileCanvas.SetActive(true);
        Debug.Log("�̹��� ������ ĵ���� ����");
    }

    public void GaugeImage(float amount)
    {
        if (gaugeImage != null)
        {
            gaugeImage.fillAmount = Mathf.Clamp(gaugeImage.fillAmount + amount, 0f, 1f);
        }
    }

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
